using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using DADH.Entities;
using DADH.IRepositories;
using DADH.Model;
using DADH.Model.Order;

namespace DADH.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<OrderModel> Order(long id)
        {
            return await Task.Run(async () =>
            {
                OrderModel model = new OrderModel();
                var order = await _context.Order.FirstOrDefaultAsync(r => r.id == id);
                if (order == null)
                {
                    return new OrderModel();
                }
                model = _mapper.Map<OrderModel>(order);
                model.products = await (from a in _context.Order_Detail
                                        join c in _context.Product on a.product_id equals c.id
                                        where a.order_id == id
                                        select new OrderProduct
                                        {
                                            name = c.name,
                                            order_id = a.id,
                                            price = a.price,
                                            packing_code = a.packing_code,
                                            product_id = a.product_id,
                                            quantity = a.quantity,
                                            unit_code = a.unit_code,
                                        }).ToListAsync();

                return model;
            });
        }
        public async Task<PaginationSet<OrderModel>> OrderList(OrderSearch search)
        {
            await Task.CompletedTask;
            PaginationSet<OrderModel> response = new();
            IQueryable<OrderModel> listItem = from a in _context.Order where a.is_delete == false
                                              select new OrderModel
                                              {
                                                  id = a.id,
                                                  code = a.code,
                                                  customer_adress = a.customer_adress ?? string.Empty,
                                                  customer_name = a.customer_name ?? string.Empty,
                                                  customer_phone = a.customer_phone ?? string.Empty,
                                                  status_id = a.status_id,
                                                  dateAdded = a.dateAdded,
                                                  order_lines = _context.Order_Detail.Where(x => x.order_id == a.id).ToList()
                                              };

            if (!string.IsNullOrEmpty(search.keyword))
            {
                listItem = listItem.Where(r => r.code.Contains(search.keyword)
                || r.customer_name.Contains(search.keyword)
                || r.customer_phone.Contains(search.keyword)
                );
            }
           
            if (search.start_date != null)
            {
                listItem = listItem.Where(r => r.dateAdded >= search.start_date);
            }
            if (search.end_date != null)
            {
                listItem = listItem.Where(r => search.end_date.Value.AddDays(1) >= r.dateAdded);
            }
            if (search.page_number > 0)
            {
                response.totalcount = listItem.Select(x => x.id).Count();
                response.page = search.page_number;
                response.maxpage = (int)Math.Ceiling((decimal)response.totalcount / search.page_size);
                response.lists = await listItem.OrderByDescending(r => r.dateAdded).Skip(search.page_size * (search.page_number - 1)).Take(search.page_size).ToListAsync();
            }
            else
            {
                response.lists = await listItem.OrderByDescending(r => r.dateAdded).ToListAsync();
            }
            return response;
        }
        public async Task<List<OrderModel>> OrderList2()
        {
            await Task.CompletedTask;
            List<OrderModel> response = new();
            IQueryable<OrderModel> listItem = from a in _context.Order
                                             
                                              where !a.is_delete 
                                              select new OrderModel
                                              {
                                                  id = a.id,
                                                  code = a.code,
                                                  customer_adress = a.customer_adress ?? string.Empty,
                                                  customer_name = a.customer_name ?? string.Empty,
                                                  customer_phone = a.customer_phone ?? string.Empty,
                                                  status_id = a.status_id,
                                                  dateAdded = a.dateAdded,
                                                  order_lines = _context.Order_Detail.Where(x => x.order_id == a.id).ToList()
                                              };

            response = await listItem.OrderByDescending(r => r.dateAdded).ToListAsync();
            return response;
        }
        public async Task<string> OrdersCreate(List<OrderModel> orders)
        {
            try
            {
                foreach (var item in orders)
                {
                    await OrderCreate(item);
                }
                return "ok";
            }
            catch (Exception ex)
            {
                return "false";

            }
        }
        public async Task<OrderModel> OrderCreate(OrderModel orders)
        {
            return await Task.Run(async () =>
            {
                using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        Order order = _mapper.Map<Order>(orders);
                        order.dateAdded = DateTime.Now;
                        int count = _context.Order.Count(x => x.code.Contains(orders.code));
                        count++;
                        order.code += count;
                        _context.Order.Add(order);
                        foreach (var item in orders.order_lines)
                        {
                            item.order_id = order.id;
                        }
                        _context.Order_Detail.AddRange(orders.order_lines);
                        _context.SaveChanges();
                        transaction.Commit();
                        OrderModel order_response = _mapper.Map<OrderModel>(order);
                        order_response.order_lines = orders.order_lines;
                        return order_response;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return new OrderModel();
                    }
                }
            });
        }
        public async Task<OrderModel> OrderModify(OrderModel orderModel)
        {
            return await Task.Run(async () =>
            {
                using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        Order order = await _context.Order.FirstOrDefaultAsync(x => x.id == orderModel.id);
                        order.dateUpdated = DateTime.Now;
                        order.code = orderModel.code;
                        order.status_id = orderModel.status_id;
                        _context.Order.Update(order);
                        _context.SaveChanges();
                        //remove order_lines
                        List<Order_Detail> order_detailDB = await _context.Order_Detail.Where(x => x.order_id == orderModel.id && !x.is_delete).ToListAsync();
                        order_detailDB.ForEach(x => x.is_delete = true);
                        _context.Order_Detail.UpdateRange(order_detailDB);
                        _context.Order_Detail.AddRange(orderModel.order_lines);
                        _context.SaveChanges();
                        transaction.Commit();
                        return orderModel;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return new OrderModel();
                    }
                }
            });
        }
        public async Task<string> OrderDelete(long id)
        {
            return await Task.Run(async () =>
            {
                using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        Order orderDB = await _context.Order.FirstOrDefaultAsync(x => x.id == id);
                        orderDB.is_delete = true;
                        _context.Order.Remove(orderDB);
                        List<Order_Detail> order_detailDB = await _context.Order_Detail.Where(x => x.order_id == id).ToListAsync();
                        order_detailDB.ForEach(x => x.is_delete = true);
                        _context.Order_Detail.UpdateRange(order_detailDB);
                        _context.SaveChanges();
                        transaction.Commit();
                        return "0";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Exception: " + ex.Message;
                    }
                }
            });
        }

    }
}

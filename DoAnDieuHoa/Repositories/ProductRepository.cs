using AutoMapper;
using DADH.Entities;
using DADH.IRepositories;
using DADH.Model;
using DADH.Model.Product;
using Microsoft.EntityFrameworkCore;

namespace DADH.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductModel> Product(long id)
        {

            var product = _context.Product.Where(r => r.id == id).FirstOrDefault();
            ProductModel model = _mapper.Map<ProductModel>(product);
            return model;

        }
        public async Task<PaginationSet<ProductViewModel>> ProductList(string? keyword, int page_size, int page_number)
        {
            return await Task.Run(() =>
            {
                PaginationSet<ProductViewModel> response = new PaginationSet<ProductViewModel>();
                IEnumerable<ProductViewModel> listItem = from a in _context.Product
                                                         where !a.is_delete
                                                         select new ProductViewModel
                                                         {
                                                             name = a.name,
                                                             price = a.price,
                                                             packing_code = a.packing_code,
                                                             unit_code = a.unit_code,
                                                             avata = a.avata,
                                                             barcode = a.barcode,
                                                             code = a.code,
                                                             is_active = a.is_active,
                                                             dateAdded = a.dateAdded,
                                                             note = a.note,
                                                             id = a.id,
                                                             userAdded = a.userAdded,
                                                             userUpdated = a.userUpdated,
                                                         };
                if (keyword != null && keyword != "")
                {

                    listItem = listItem.Where(r => r.name.Contains(keyword) || r.code.Contains(keyword) || (r.barcode != null && r.barcode.Contains(keyword)) || r.name.ToLower().Contains(keyword.ToLower()));
                }
               
                if (page_number > 0)
                {
                    response.totalcount = listItem.Select(x => x.id).Count();
                    response.page = page_number;
                    response.maxpage = (int)Math.Ceiling((decimal)response.totalcount / page_size);
                    response.lists = listItem.OrderByDescending(r => r.id).Skip(page_size * (page_number - 1)).Take(page_size).ToList();
                }
                else
                {
                    response.lists = listItem.OrderByDescending(r => r.id).ToList();
                }
                return response;
            });
        }

        public async Task<Product> ProductCreate(Product product)
        {
            return await Task.Run(async () =>
            {
                product.dateAdded = DateTime.Now;
                _context.Product.Add(product);
                _context.SaveChanges();
                return product;
            });
        }
        public async Task<bool> ProductDelete(long product_id, long user_id)
        {
            return await Task.Run(() =>
            {
                var model = _context.Product.Where(r => r.id == product_id).FirstOrDefault();
                if (model == null || model.id == 0)
                {
                    return Task.FromResult(false);
                }
                else
                {
                    model.userUpdated = user_id;
                    model.dateUpdated = DateTime.Now;
                    model.is_delete = true;
                    _context.Product.Update(model);
                }
                _context.SaveChanges();
                return Task.FromResult(true);
            });
        }
        public async Task<Product> ProductModify(Product product)
        {
            return await Task.Run(() =>
            {
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    _context.Product.Update(product);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    transaction.Rollback();

                    throw;
                }

                return Task.FromResult(product);
            });
        }

    }
}

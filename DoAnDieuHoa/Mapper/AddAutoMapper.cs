using AutoMapper;
using DADH.Entities;
using DADH.Model;
using DADH.Model.Customer;
using DADH.Model.Product;
using DADH.Model.User;

namespace DADH.Mapper
{
    public class AddAutoMapper : Profile
    {
        public AddAutoMapper()
        {
            CreateMap<Admin_User, UserCreateModel>();
            CreateMap<UserCreateModel, Admin_User>();
            CreateMap<Admin_User, UserModifyModel>();
            CreateMap<UserModifyModel, Admin_User>();
            CreateMap<Admin_User, UserModel>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();


            CreateMap<Voucher, VoucherModel>();
            CreateMap<VoucherModel, Voucher>();
            
            CreateMap<Order, OrderModel>();
            CreateMap<OrderModel, Order>();

            CreateMap<PartnerModel, Partner>();
            CreateMap<Partner, PartnerModel>();


          
            CreateMap<CustomerModel, Customer>();
            CreateMap<Customer, CustomerModel>();

          

        }
    }
}

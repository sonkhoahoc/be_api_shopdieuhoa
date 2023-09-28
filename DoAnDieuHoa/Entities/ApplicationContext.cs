using Microsoft.EntityFrameworkCore;
using DADH.Controllers;

namespace DADH.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public virtual DbSet<Admin_User> Admin_User { set; get; }
     
        public virtual DbSet<Product> Product { set; get; }
      
        public virtual DbSet<Voucher> Voucher { set; get; }
        public virtual DbSet<Order> Order { set; get; }
        public virtual DbSet<Order_Detail> Order_Detail { set; get; }
        public virtual DbSet<Customer> Customer { set; get; }
        public virtual DbSet<Category_Product> Category_Product { set; get; }
    
         

    }
}

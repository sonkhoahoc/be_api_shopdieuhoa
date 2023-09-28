using DADH.Entities;
using DADH.Model;
using DADH.Model.Product;

namespace DADH.IRepositories
{
    public interface IProductRepository
    {
        Task<ProductModel> Product(long id);
        Task<Product> ProductCreate(Product product);
        Task<bool> ProductDelete(long product_id, long user_id);
        Task<Product> ProductModify(Product product);
        Task<PaginationSet<ProductViewModel>> ProductList(string? keyword, int page_size, int page_number);
      

    }
}

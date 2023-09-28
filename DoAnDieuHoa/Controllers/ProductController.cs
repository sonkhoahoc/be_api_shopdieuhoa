using ECom.Framework.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DADH.Entities;
using DADH.Extensions;
using DADH.IRepositories;
using DADH.Model;
using DADH.Model.Product;

namespace DADH.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductController(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("product")]
        public async Task<IActionResult> Product(long id)
        {
            try
            {
                var products = await this._productRepository.Product(id);
                return Ok(new ResponseSingleContentModel<ProductModel>
                {
                    StatusCode = 200,
                    Message = "Lấy danh sách thành công.",
                    Data = products
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý",
                    Data = null
                });
            }
        }
        [HttpPost("product-create")]
        public async Task<IActionResult> ProductCreate([FromBody] Product model)
        {
            try
            {
                var validator = ValitRules<Product>
                    .Create()
                    .For(model)
                    .Validate();
                if (validator.Succeeded)
                {
                    model.userAdded = userid(_httpContextAccessor);
                    var product = await this._productRepository.ProductCreate(model);
                    return Ok(new ResponseSingleContentModel<Product>
                    {
                        StatusCode = 200,
                        Message = "Thêm mới thành công",
                        Data = product
                    });
                }
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 400,
                    Message = validator.ErrorMessages.JoinNewLine(),
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý",
                    Data = null
                });
            }
        }
        [HttpPost("product-modify")]
        public async Task<IActionResult> ProductModify([FromBody] Product model)
        {
            try
            {
                var validator = ValitRules<Product>
                    .Create()
                    .Ensure(m => m.price, rule => rule.IsGreaterThan(0))
                  .Ensure(m => m.barcode, rule => rule.Required())
                    .Ensure(m => m.id, rule => rule.IsGreaterThan(0))
                    //.Ensure(m => m.note, rule => rule.Required())
                    .For(model)
                    .Validate();

                if (validator.Succeeded)
                {
                    var product = await this._productRepository.ProductModify(model);
                    model.userUpdated = userid(_httpContextAccessor);
                    return Ok(new ResponseSingleContentModel<Product>
                    {
                        StatusCode = 200,
                        Message = "Cập nhật thành công",
                        Data = product
                    });
                }

                // Return invalidate data
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 400,
                    Message = validator.ErrorMessages.JoinNewLine(),
                    Data = null
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý",
                    Data = null
                });
            }
        }
        [HttpDelete("product-delete")]
        public async Task<IActionResult> ProductDelete(long product_id)
        {
            try
            {
                long user_id = userid(_httpContextAccessor);

                var response = await this._productRepository.ProductDelete(product_id, user_id);
                return response
                    ? Ok(new ResponseSingleContentModel<string>
                    {
                        StatusCode = 200,
                        Message = "Cập nhật thành công",
                        Data = ""
                    })
                    : (IActionResult)Ok(new ResponseSingleContentModel<IResponseData>
                    {
                        StatusCode = 500,
                        Message = "Không tìm thấy bản ghi",
                        Data = null
                    });
            }
            catch (Exception)
            {
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý",
                    Data = null
                });
            }
        }
        [HttpPost("product-list")]
        public async Task<IActionResult> ProductList(ProductSearchModel search)
        {
            try
            {
                var products = await this._productRepository.ProductList(search.keyword, search.page_size, search.page_number);
                return Ok(new ResponseSingleContentModel<PaginationSet<ProductViewModel>>
                {
                    StatusCode = 200,
                    Message = "Lấy danh sách thành công.",
                    Data = products
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý",
                    Data = null
                });
            }
        }

    }
}

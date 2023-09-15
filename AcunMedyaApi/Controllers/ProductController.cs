using BuiseneesLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http.Cors;

namespace AcunMedyaApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private static readonly ILogger<ProductController> logger;
        private readonly IProduct _product;
        public ProductController(ILogger<ProductController> _logger)
        {
            _logger = logger;
            _product = new BuiseneesCodes();
        }

        [HttpGet("products-id")]
        public async Task<ProductModel> GetProductsById(int Id)
        {

            ILogger logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<ProductController>();
            logger.LogInformation(1, "About page visited at {DT}", DateTime.UtcNow.ToLongTimeString());

            //  IProduct product = new BuiseneesCodes();
            return await _product.ProductsById(Id);
        }
        [HttpGet("products-like")]
        public async Task<List<ProductModel>> LikeProduct(int Id)
        {
            return await _product.LikeProduct(Id);
        }
        [HttpGet("products-buy")]
        public async Task<List<ProductModel>> BuyProduct()
        {
            return await _product.BuyProduct();
        }
        [HttpGet("products-buy-user")]
        public async Task<List<ProductModel>> BuyProductsGetUser(int userId)
        {
            return await _product.BuyProductsGetUser(userId);
        }
        [HttpGet("products-kampanya")]
        public async Task<List<ProductModel>> KampanyaProduct()
        {
            return await _product.KampanyaProduct();
        }
        [HttpGet("products-all")]
        public async Task<List<ProductModel>> GetProducts()
        {
            return await _product.Products();
        }
        [HttpGet("products-examined")]
        public async Task<List<ProductModel>> ExaminedProductAll(int userId)
        {
            return await _product.ExaminedProductAll(userId);
        }
        [HttpGet("card")]
        public async Task<List<ProductModel>> GetCard(int Id)
        {
            return await _product.ProductCard(Id);

        }
        [HttpPost("products-post")]
        public async Task<string> PostProduct(ProductModel productModel)
        {
            await _product.PostProduct(productModel);
            return "KAYIT BAŞARILI";
        }
        [HttpPost("products-post-card")]
        public async Task<string> PostProductInCard(int productId, int userId)
        {
            await _product.PostProductInCard(productId, userId);
            return "Ürün Sepere Eklendi";
        }
        [HttpPost("products-post-liked")]
        public async Task<ProductModel> LikeProduct(int productId, int userId)
        {
            return await _product.LikeData(productId, userId);
        }
        [HttpPost("products-examined-last")]
        public async Task<ProductModel> ExaminedProduct(int productId, int userId)
        {
            return await _product.ExaminedProduct(productId, userId);
        }
        [HttpPost("products-buy")]
        public async Task<ProductModel> BuyProductsUser(int productId, int userId)
        {
            return await _product.BuyProductsUser(productId, userId);
        }
        [HttpPut("products-uptade")]
        public async Task<ProductModel> UpdateProduct(ProductModel productModel)
        {
            return await _product.UpdateProduct(productModel);
        }
        [HttpDelete("product-delete")]
        public async Task<string> ProductDelete(int Id)
        {
            await _product.ProductDelete(Id);
            return "Product silindi";
        }
        [HttpDelete("product-delete-card")]
        public async Task<ProductModel> ProductDeleteInCard(int userId, int Id)
        {
            return await _product.ProductDeleteInCard(userId, Id);
        }
        [HttpDelete("product-delete-liked")]
        public async Task<string> LikedDelete(int productId, int userId)
        {
            await _product.LikedDelete(productId, userId);
            return "Beğeniden silindi";
        }
    }
}

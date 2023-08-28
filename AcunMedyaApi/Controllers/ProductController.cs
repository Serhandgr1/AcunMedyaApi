using BuiseneesLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AcunMedyaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        [HttpGet("products-id")]
        public ProductModel GetProductsById(int Id)
        {
            IProduct product = new BuiseneesCodes();
            return product.ProductsById(Id);
        }
        [HttpGet("products-all")]
        public List<ProductModel> GetProducts()
        {
            IProduct product = new BuiseneesCodes();
            return product.Products();
        }
        [HttpGet("card")]
        public List<ProductModel> GetCard(int Id)
        {
            IProduct product = new BuiseneesCodes();
            return product.ProductCard(Id);

        }
       
        [HttpPost("products-post")]
        public string PostProduct(ProductModel productModel)
        {
            IProduct product = new BuiseneesCodes();
            product.PostProduct(productModel);
            return "KAYIT BAŞARILI";
        }
        [HttpPut("products-uptade")]
        public ProductModel UpdateProduct(ProductModel productModel)
        {
            IProduct product = new BuiseneesCodes();
            return product.UpdateProduct(productModel);
        }

        [HttpDelete("product-delete")]
        public string ProductDelete(int Id)
        {
            IProduct product = new BuiseneesCodes();
            product.ProductDelete(Id);
            return "Product silindi";
        }
    }
}

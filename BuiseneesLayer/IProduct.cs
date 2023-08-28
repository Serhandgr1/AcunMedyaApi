using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiseneesLayer
{
    public interface IProduct
    {
        List<ProductModel> Products();
        void PostProduct(ProductModel productModel);
        List<ProductModel> ProductCard(int Id);
        void ProductDelete(int Id);
        ProductModel ProductsById(int Id);
        ProductModel UpdateProduct(ProductModel productModel);
    }
}

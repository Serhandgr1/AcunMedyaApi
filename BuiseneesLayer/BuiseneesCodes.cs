using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BuiseneesLayer
{
    public class BuiseneesCodes : IProduct, IUser
    {
        DataContext context = new DataContext();
        public string Name(int Id) 
        {
            string query = "SELECT Name FROM Users WHERE UserId=@UserId";
            SqlCommand sqlCommand = context.CreateCommand(query);
            sqlCommand.Parameters.AddWithValue("UserId", Id); 
            SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read()) 
            {
                return reader["Name"].ToString();
            }
                return "İstenen Idye ait değer bulunamadı";               
        }
        public ProductModel ProductsById(int Id)
        {
            return context.ProductsById(Id);
        }
        public List<ProductModel> Products()
        {
            return context.Products();
        }

        public List<ProductModel> ProductCard(int Id)
        {    
            return context.ProductsCard(Id);
        }
        public ProductModel UpdateProduct(ProductModel productModel) 
        {
            return context.UpdateProduct(productModel);
        }
        public UserModel UpdateUser(UserModel userModel)
        {
            return context.UpdateUser(userModel);
        }
        public UserModel User(int Id)
        {
            return context.User(Id);    
        }
        public void PostProduct(ProductModel productModel)
        {
            context.PostProduct(productModel);
        }
        public void PostUser(UserModel userModel)
        {
            context.PostUser(userModel);
        }
        public void UserDelete(int Id)
        {
            context.UserDelete(Id);
        }
        public void ProductDelete(int Id)
        {
            context.ProductDelete(Id);
        }

    }
}

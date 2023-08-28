using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class DataContext
    {

       

            public SqlConnection DbSqlConnection()
            {
                SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=E_COMMERCE;Trusted_Connection=True;");
                sqlConnection.Open();
                return sqlConnection;
            }
            public SqlCommand CreateCommand(string query)
            {
                SqlCommand sqlCommand = new SqlCommand(query, DbSqlConnection());
                return sqlCommand;

            }
            public ProductModel ProductsById(int Id) 
            {
            ProductModel product = new ProductModel();
            string query = "SELECT * FROM Products WHERE ProductId=@ProductId";
                SqlCommand command =  CreateCommand(query);
                command.Parameters.AddWithValue("@ProductId", Id);  
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                product.ProductId = Convert.ToInt32( reader["ProductId"].ToString());
                product.ProductName = reader["ProductName"].ToString();
                product.ProductDetail = reader["ProductDetail"].ToString();
                product.Price = Convert.ToDecimal(reader["Price"].ToString());
                product.BrandId = Convert.ToInt32(reader["BrandId"].ToString());
                product.CategoryId = Convert.ToInt32(reader["CategoryId"].ToString());
                product.ModelId = Convert.ToInt32(reader["ModelId"].ToString());
                product.ProductImage = reader["ProductImage"].ToString();
                product.ProductOzet = reader["ProductOzet"].ToString();
                product.Stock = Convert.ToInt32(reader["Stock"].ToString());
                }
            return product;
        }
        public ProductModel UpdateProduct(ProductModel productModel) 
        {
            string query = "UPDATE Products SET ProductName=@ProductName , Price=@Price , CategoryId=@CategoryId , BrandId=@BrandId , ModelId=@ModelId , Stock=@Stock , ProductDetail=@ProductDetail, ProductImage=@ProductImage , ProductOzet=@ProductOzet WHERE ProductId=@ProductId";   
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@ProductId", productModel.ProductId);
            command.Parameters.AddWithValue("@ProductName" , productModel.ProductName);
            command.Parameters.AddWithValue("@Price", productModel.Price);
            command.Parameters.AddWithValue("@CategoryId", productModel.CategoryId);
            command.Parameters.AddWithValue("@BrandId", productModel.BrandId);
            command.Parameters.AddWithValue("@ModelId", productModel.ModelId);
            command.Parameters.AddWithValue("@Stock", productModel.Stock);
            command.Parameters.AddWithValue("@ProductDetail", productModel.ProductDetail);
            command.Parameters.AddWithValue("@ProductImage", productModel.ProductImage);
            command.Parameters.AddWithValue("@ProductOzet", productModel.ProductOzet);
            command.ExecuteNonQuery();
            return productModel;
        }
        public UserModel UpdateUser(UserModel userModel)
        {
            string query = "UPDATE Users SET UserName=@UserName , Name=@Name , Surname=@Surname , E_Mail=@E_Mail , Password=@Password , RoleId=@RoleId WHERE UserId=@UserId";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@UserId", userModel.UserId);
            command.Parameters.AddWithValue("@UserName", userModel.UserName);
            command.Parameters.AddWithValue("@Name", userModel.Name);
            command.Parameters.AddWithValue("@Surname", userModel.Surname);
            command.Parameters.AddWithValue("@E_Mail", userModel.E_Mail);
            command.Parameters.AddWithValue("@Password", userModel.Password);
            command.Parameters.AddWithValue("@RoleId", userModel.RoleId);
            command.ExecuteNonQuery();
            return userModel;
        }
        public List<ProductModel> Products()
        {
           List<ProductModel> productsModel = new List<ProductModel>();
            string query = "SELECT * FROM Products";
            SqlCommand command = CreateCommand(query);
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                product.ProductName = reader["ProductName"].ToString();
                product.ProductDetail = reader["ProductDetail"].ToString();
                product.Price = Convert.ToDecimal(reader["Price"].ToString());
                product.BrandId = Convert.ToInt32(reader["BrandId"].ToString());
                product.CategoryId = Convert.ToInt32(reader["CategoryId"].ToString());
                product.ModelId = Convert.ToInt32(reader["ModelId"].ToString());
                product.ProductImage = reader["ProductImage"].ToString();
                product.ProductOzet = reader["ProductOzet"].ToString();
                product.Stock = Convert.ToInt32(reader["Stock"].ToString());
                productsModel.Add(product);
            }
            return productsModel;
        }

        public List<ProductModel> ProductsCard(int Id)
        {
            List<ProductModel> productsModel = new List<ProductModel>();
            string query = "SELECT ProductId FROM ProductsInCart WHERE UserId=@UserId";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@UserId", Id);
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ProductId"].ToString());
                productsModel.Add(ProductsById(id));
            }
            return productsModel;
        }
        public UserModel User(int Id)
        {
            UserModel user = new UserModel();
            string query = "SELECT * FROM Users WHERE UserId=@UserId";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@UserId", Id);
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                user.UserName = reader["UserName"].ToString();
                user.Name = reader["Name"].ToString();
                user.Surname = reader["Surname"].ToString();
                user.E_Mail= reader["E_Mail"].ToString();
                user.Password = reader["Password"].ToString();
                user.RoleId = Convert.ToInt32(reader["RoleId"].ToString());
                return user;
            }
            return user;

        }
        public void PostProduct(ProductModel productModel) 
        {
            string query = "INSERT INTO Products (ProductName , Price , CategoryId , BrandId , ModelId , Stock , ProductDetail, ProductImage , ProductOzet) VALUES (@ProductName,@Price,@CategoryId,@BrandId,@ModelId,@Stock,@ProductDetail,@ProductImage,@ProductOzet)";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@ProductName", productModel.ProductName);
            command.Parameters.AddWithValue("@Price", productModel.Price);
            command.Parameters.AddWithValue("@CategoryId", productModel.CategoryId);
            command.Parameters.AddWithValue("@BrandId", productModel.BrandId);
            command.Parameters.AddWithValue("@ModelId", productModel.ModelId);
            command.Parameters.AddWithValue("@Stock", productModel.Stock);
            command.Parameters.AddWithValue("@ProductDetail", productModel.ProductDetail);
            command.Parameters.AddWithValue("@ProductImage", productModel.ProductImage);
            command.Parameters.AddWithValue("@ProductOzet", productModel.ProductOzet);
            command.ExecuteNonQuery();
        }
        public void PostUser(UserModel userModel)
        {
            string query = "INSERT INTO Users (UserName , Name , Surname , E_Mail , Password , RoleId) VALUES (@UserName,@Name,@Surname,@E_Mail,@Password,@RoleId)";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@UserName", userModel.UserName);
            command.Parameters.AddWithValue("@Name", userModel.Name);
            command.Parameters.AddWithValue("@Surname", userModel.Surname);
            command.Parameters.AddWithValue("@E_Mail", userModel.E_Mail);
            command.Parameters.AddWithValue("@Password", userModel.Password);
            command.Parameters.AddWithValue("@RoleId", userModel.RoleId);
            command.ExecuteNonQuery();
        }
        public void UserDelete(int Id)
        {
            string query = "DELETE FROM Users WHERE UserId=@UserId";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@UserId", Id);
            command.ExecuteNonQuery();

        }
        public void ProductDelete(int Id)
        {
            string query = "DELETE FROM Products WHERE ProductId=@ProductId";
            SqlCommand command = CreateCommand(query);
            command.Parameters.AddWithValue("@ProductId", Id);
            command.ExecuteNonQuery();

        }
    }
}


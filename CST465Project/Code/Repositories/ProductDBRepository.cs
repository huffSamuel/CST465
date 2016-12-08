using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CST465Project
{
    public class ProductDBRepository : IDataEntityRepository<Product>
    {
        public Product Get(int id)
        {
            Product outValue = new Product();
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Product WHERE ID=@ID";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        outValue.ID = id;
                        outValue.ProductCode = reader["ProductCode"].ToString();
                        outValue.CategoryID = (int)reader["CategoryID"];
                        outValue.Price = float.Parse(reader["Price"].ToString());
                        outValue.ProductDescription = reader["ProductDescription"].ToString();
                        outValue.ProductName = reader["ProductName"].ToString();
                        outValue.Quantity = (int)reader["Quantity"];
                        outValue.ImageContentType = reader["ImageContentType"].ToString();
                        outValue.ImageFileName = reader["ImageFileName"].ToString();
                        object image = reader["ProductImage"];
                        BinaryFormatter bf = new BinaryFormatter();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bf.Serialize(ms, image);
                            outValue.ProductImage = ms.ToArray();
                        }
                            
                    }
                }
            }
            return outValue;
        }

        public List<Product> GetList()
        {
            List<Product> outValue = new List<Product>();

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Product";
                cmd.CommandType = CommandType.Text;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Product temp = new Product();
                    temp.CategoryID = (int)reader["CategoryID"];
                    temp.ID = (int)reader["ID"];
                    temp.Price = float.Parse(reader["Price"].ToString());
                    temp.ProductCode = reader["ProductCode"].ToString();
                    temp.ProductDescription = reader["ProductDescription"].ToString();
                    temp.ProductName = reader["ProductName"].ToString();
                    temp.Quantity = (int)reader["Quantity"];
                    temp.ImageContentType = reader["ImageContentType"].ToString();
                    temp.ImageFileName = reader["ImageFileName"].ToString();
                    temp.ProductImage = (byte[])reader["ProductImage"];
                    outValue.Add(temp);
                }
            }
            return outValue;
        }

        public void Save(Product entity)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                if (entity.ID != 0)
                {
                    cmd.CommandText = "UPDATE Product SET ProductCode=@ProductCode, ProductName=@ProductName, ImageFileName=@ImageFileName, ImageContentType=@ImageContentType, CategoryID=@CategoryID, ProductDescription=@ProductDescription, ProductImage=@ProductImage, Price=@Price, Quantity=@Quantity WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", entity.ID);
                }
                else
                    cmd.CommandText = "INSERT INTO Product (ProductCode, ProductName, CategoryID, ImageFileName, ImageContentType, ProductDescription, ProductImage, Price, Quantity) VALUES (@ProductCode, @ProductName, @CategoryID, @ImageFileName, @ImageContentType, @ProductDescription, @ProductImage, @Price, @Quantity)";

                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProductCode", entity.ProductCode);
                cmd.Parameters.AddWithValue("@ProductName", entity.ProductName);
                cmd.Parameters.AddWithValue("@CategoryID", entity.CategoryID);
                cmd.Parameters.AddWithValue("@ProductDescription", entity.ProductDescription);
                if(!string.IsNullOrEmpty(entity.ImageFileName))
                {
                    cmd.Parameters.AddWithValue("@ProductImage", entity.ProductImage);
                    cmd.Parameters.AddWithValue("@ImageFileName", entity.ImageFileName);
                    cmd.Parameters.AddWithValue("@ImageContentType", entity.ImageContentType);
                }
                    
                else
                {
                    cmd.Parameters.AddWithValue("@ProductImage", 0);
                    cmd.Parameters.AddWithValue("@ImageContentType", "null");
                    cmd.Parameters.AddWithValue("@ImageFileName", "null");
                }
                cmd.Parameters.AddWithValue("@Price", entity.Price);
                cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Product WHERE ID=@ID";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
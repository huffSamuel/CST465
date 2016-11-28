using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465Project
{
    public class CategoryDBRepository : IDataEntityRepository<Category>
    {
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Category WHERE ID=@ID";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public Category Get(int id)
        {
            Category outValue = new CST465Project.Category();
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Category WHERE ID=@ID";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        outValue.ID = id;
                        outValue.CategoryName = reader["CategoryName"].ToString();
                    }
                }

            }
            return outValue;
        }

        public List<Category> GetList()
        {
            List<Category> outValue = new List<Category>();

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Category";
                cmd.CommandType = CommandType.Text;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Category temp = new Category();
                    temp.ID = (int)reader["ID"];
                    temp.CategoryName = reader["CategoryName"].ToString();
                    outValue.Add(temp);
                }
            }
            return outValue;
        }

        public void Save(Category entity)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                if (entity.ID != 0)
                {
                    cmd.CommandText = "UPDATE Category SET CategoryName=@CategoryName WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", entity.ID);
                }
                else
                    cmd.CommandText = "INSERT INTO Category (CategoryName) VALUES (@CategoryName)";

                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}
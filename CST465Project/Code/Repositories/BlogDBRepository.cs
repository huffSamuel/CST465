using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465Project
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        public BlogPost Get(int id)
        {
            BlogPost outValue = new BlogPost();

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Blog WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            outValue.ID = id;
                            outValue.Author = reader["Author"].ToString();
                            outValue.Title = reader["Title"].ToString(); ;
                            outValue.Content = reader["Content"].ToString();
                            outValue.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                        }
                    }
                } 
            }

            return outValue;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> outValue = new List<BlogPost>();

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Blog";
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BlogPost temp = new BlogPost();
                        temp.ID = (int)reader["ID"];
                        temp.Author = reader["Author"].ToString();
                        temp.Title = reader["Title"].ToString();
                        temp.Content = reader["Content"].ToString();
                        temp.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                        outValue.Add(temp);
                    }
                }
            }

            return outValue;
        }

        public void Save(BlogPost entity)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                if (entity.ID != 0)
                {
                    cmd.CommandText = "UPDATE Blog SET Author=@Author, Title=@Title, Content=@Content WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", entity.ID);
                }
                else
                    cmd.CommandText = "INSERT INTO Blog (Author, Title, Content) VALUES (@Author, @Title, @Content)";

                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Author", entity.Author);

                cmd.Parameters.AddWithValue("@Title", entity.Title);
                cmd.Parameters.AddWithValue("@Content", entity.Content);
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.IO;

namespace CST465Project
{
    public class BlogJSONRepository : IDataEntityRepository<BlogPost>
    {
        public BlogPost Get(int id)
        {
            BlogPost outValue = new BlogPost();
            List<BlogPost> repository;
            JavaScriptSerializer jss = new JavaScriptSerializer();

            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("/App_Data/jsonRepository.json")))
            {
                repository = jss.Deserialize<List<BlogPost>>(sr.ReadToEnd());
            }

            outValue = repository.FirstOrDefault(m => m.ID == id); 
            return outValue;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> blogPosts;

            JavaScriptSerializer jss = new JavaScriptSerializer();
            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("/App_Data/jsonRepository.json")))
            {
                blogPosts = jss.Deserialize<List<BlogPost>>(sr.ReadToEnd());
            }

            return blogPosts;
        }

        public void Save(BlogPost entity)
        {
            List<BlogPost> repository = GetList();
            JavaScriptSerializer jss = new JavaScriptSerializer();

            if (repository == null)
                repository = new List<BlogPost>();

            if(entity.ID == 0)
            {
                if(repository.Count == 0)
                {
                    entity.ID = 1;
                }
                else
                {
                    entity.ID = repository.Max(s => s.ID) + 1;
                }
                entity.Timestamp = DateTime.Now; ;
                repository.Add(entity);
            }
            else
            {
                BlogPost temp = repository.Where(m => m.ID == entity.ID).First();
                temp.Title = entity.Title;
                temp.Content = entity.Content;
            }

            using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("/App_Data/jsonRepository.json")))
            {
                sw.Write(jss.Serialize(repository));
            }

        }
    }
}
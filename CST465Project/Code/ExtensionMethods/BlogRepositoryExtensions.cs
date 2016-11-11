using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465Project
{
    public static class BlogRepositoryExtensions
    {
        public static List<BlogPost> GetListByContent(this IDataEntityRepository<BlogPost> repo, string content)
        {
            List<BlogPost> outValue = new List<BlogPost>();
            outValue.AddRange(repo.GetList().Where(m => m.Content.Contains(content) || m.Title.Contains(content)));
            return outValue;
        }
    }
}
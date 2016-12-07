using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465Project
{
    public static class ProductRespositoryExtensions
    {
        public static List<Product> GetListByCategoryID(this IDataEntityRepository<Product> repo, int categoryID)
        {
            List<Product> outValue = new List<Product>();
            outValue.AddRange(repo.GetList().Where(m => m.CategoryID == categoryID));
            return outValue;
        }

        public static List<Product> GetListBySearch(this IDataEntityRepository<Product> repo, string search)
        {
            List<Product> outValue = new List<Product>();
            outValue.AddRange(repo.GetList().Where(m => m.ProductName.Contains(search) || m.ProductDescription.Contains(search)));
            return outValue;
        }
    }
}
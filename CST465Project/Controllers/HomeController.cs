using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Project.Controllers
{
    public class HomeController : Controller
    {
        private IDataEntityRepository<BlogPost> _repository = new BlogDBRepository();
        private IDataEntityRepository<Product> _products = new ProductDBRepository();
        // GET: Home
        public ActionResult Index()
        {
            HomeModel m = new HomeModel();
            // Get a list of the 3 most recent blogs
            List<BlogPost> blogs = _repository.GetList();
            m.blogs = blogs.OrderByDescending(i => i.ID).Take(3).ToList();

            // Get list of all products
            List<Product> products = _products.GetList();
            List<Product> prods = new List<Product>();
            if(products.Count > 0)
            {
                Random rand = new Random();
                for (int i = 0; i < (products.Count() > 5 ? 5 : products.Count()); ++i)
                {
                    prods.Add(products[rand.Next() % products.Count()]);
                }
                m.products = prods;
            }
            
            return View(m);
        }
    }
}
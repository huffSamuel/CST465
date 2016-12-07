using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CST465Project
{
    public class ProductController : Controller
    {
        private IDataEntityRepository<Product> _repository;

        public ProductController(IDataEntityRepository<Product> rep)
        {
            _repository = rep;
        }

        public ProductController()
        {
            this._repository = new ProductDBRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> list = _repository.GetList();
            InventoryModel m = new InventoryModel();
            m.products = list;
            m.categories = new SelectList(new CategoryDBRepository().GetList(), "ID", "CategoryName");

            return View(m);
        }

        [HttpPost]
        public ActionResult Index(string filter, string category)
        {
            List<Product> list;
            if(filter=="")
            {
                list = _repository.GetListByCategoryID(Int32.Parse(category));
            }
            else
            {
                list = _repository.GetListBySearch(filter);
                list.Intersect(_repository.GetListByCategoryID(Int32.Parse(category)));
            }
            InventoryModel m = new InventoryModel();
            m.products = list;
            m.categories = new SelectList(new CategoryDBRepository().GetList(), "ID", "CategoryName");

            return View(m);
        }

        public ActionResult Delete(int id)
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

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            ProductModel model = new CST465Project.ProductModel();
            model.Categories = new SelectList(new CategoryDBRepository().GetList(), "ID", "CategoryName");
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageBytes;
                Product product = new Product();
                product.ID = model.ID;
                product.CategoryID = model.CategoryID;
                product.Price = model.Price;
                product.ProductCode = model.ProductCode;
                product.ProductDescription = model.ProductDescription;
                if (model.ProductImage != null)
                {

                    using (MemoryStream ms = new MemoryStream())
                    {
                        model.ProductImage.InputStream.CopyTo(ms);
                        imageBytes = ms.ToArray();
                    }
                    product.ProductImage = imageBytes;
                    product.ImageFileName = model.ProductImage.FileName;
                    product.ImageContentType = model.ProductImage.ContentType;
                }
                else
                    product.ProductImage = null;
                
                product.ProductName = model.ProductName;
                product.Quantity = model.Quantity;
                _repository.Save(product);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                Product product = _repository.Get(id);
                ProductModel model = new ProductModel();
                model.CategoryID = product.CategoryID;
                model.ID = product.ID;
                model.Price = product.Price;
                model.ProductCode = product.ProductCode;
                model.ProductDescription = product.ProductDescription;
                model.ProductName = product.ProductName;
                model.Quantity = product.Quantity;
                model.Categories = new SelectList(new CategoryDBRepository().GetList(), "ID", "CategoryName");
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                byte[] imageBytes;
                Product product = new Product();
                product.ID = model.ID;
                product.CategoryID = model.CategoryID;
                product.Price = model.Price;
                product.ProductCode = model.ProductCode;
                product.ProductDescription = model.ProductDescription;
                if (model.ProductImage != null)
                {
                    WebCache.Remove(product.ID + "Full");
                    WebCache.Remove(product.ID + "Thumbnail");
                    using (MemoryStream ms = new MemoryStream())
                    {
                        model.ProductImage.InputStream.CopyTo(ms);
                        imageBytes = ms.ToArray();
                    }
                    product.ProductImage = imageBytes;
                    product.ImageFileName = model.ProductImage.FileName;
                    product.ImageContentType = model.ProductImage.ContentType;
                    
                }
                else
                    product.ProductImage = null;

                product.ProductName = model.ProductName;
                product.Quantity = model.Quantity;
                _repository.Save(product);
            }
            else
                return View("Edit", model);
            return RedirectToAction("Index");
            
        }

        public ActionResult Display(int ID)
        {
            Product product = _repository.Get(ID);
            return View(product);
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Project
{
    public class CategoryController : Controller
    {
        private IDataEntityRepository<Category> _repository;

        public CategoryController(IDataEntityRepository<Category> rep)
        {
            _repository = rep;
        }

        public CategoryController()
        {
            this._repository = new CategoryDBRepository();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<Category> list = _repository.GetList();
            return View(list);
        }

        public ActionResult Add()
        {
            CategoryModel model = new CST465Project.CategoryModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.ID = model.ID;
                category.CategoryName = model.CategoryName;
                _repository.Save(category);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Category category = _repository.Get(id);
                CategoryModel model = new CategoryModel();
                
                model.ID = category.ID;
                model.CategoryName = category.CategoryName;
                
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            else if (ModelState.IsValid)
            {
                Category category = new CST465Project.Category();
                category.ID = model.ID;
                category.CategoryName = model.CategoryName;
                
            }
            else
                return View(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                // DELETE FROM Product WHERE CategoryID=@ID
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Product WHERE CategoryID=@ID";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Category WHERE ID=@ID";
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Display(int ID)
        {
            Category category = _repository.Get(ID);
            return View(category);
        }
    }
}
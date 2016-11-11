using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Project.Controllers
{
    public class BlogController : Controller
    {
        private IDataEntityRepository<BlogPost> _repository;
        public BlogController(IDataEntityRepository<BlogPost> rep)
        {
            _repository = rep;
        }

        public BlogController()
        {
            this._repository = new BlogDBRepository();
        }
        // GET: Blog
        public ActionResult Index()
        {
            List<BlogPost> list = _repository.GetList();
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string filter)
        {
            List<BlogPost> list = _repository.GetListByContent(filter);
            return View(list);
        }

        public ActionResult Add()
        {
            BlogPostModel model = new BlogPostModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(BlogPostModel model)
        {
            if(ModelState.IsValid)
            {
                BlogPost post = new BlogPost();
                post.ID = model.ID;
                post.Title = model.Title;
                post.Content = model.Content;
                post.Author = model.Author;
                _repository.Save(post);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            BlogPost post = _repository.Get(id);
            BlogPostModel postmodel = new BlogPostModel();
            postmodel.Author = post.Author;
            postmodel.Content = post.Content;
            postmodel.ID = post.ID;
            postmodel.Title = post.Title;

            return View(postmodel);
        }

        [HttpPost]
        public ActionResult Edit(BlogPostModel model)
        {
            if(ModelState.IsValid)
            {
                BlogPost post = new BlogPost();
                post.Author = model.Author;
                post.Content = model.Content;
                post.ID = model.ID;
                post.Title = model.Title;
                _repository.Save(post);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Display(int ID)
        {
            BlogPost post = _repository.Get(ID);

            return View(post);
        }

    }
}
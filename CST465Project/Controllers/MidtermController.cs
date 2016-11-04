using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Project.Controllers
{
    public class MidtermController : Controller
    {
        
        //
        // GET: /Midterm/
        public ActionResult Index()
        {
            return View();
        }

        /*

        [HttpGet]
        public ActionResult TakeTest()
        {
            // Return the list of ITestQuestions
            return View();
        }

        [HttpPost]
        public ActionResult TakeTest()
        {
            // Prevent XSite Request Forgery
            // Retrieve questions from JSON file
            // Match list of IDs/Questions and list of IDs/Answers that was
            //      posted back on ID make list ID/Questions/Answers
            // Verify model meets validation rules
            if(!ModelState.IsValid)
            {
                return View();
            }
            // Set TempData["TestData"] = list of id/questions/answers
            return RedirectToAction("DisplayResults");
        }

        [HttpGet]
        public ActionResult DisplayResults()
        {
            // Retrieve list of TestQuestions from TempData
            List<TestQuestion> q = new List<TestQuestion>();
            return View(q);
        }

        List<TestQuestion> ParseJSON()
        {
            List<TestQuestion> questions = new List<TestQuestion>();

            return questions;
        }
        */
    }
}
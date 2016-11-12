using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CST465Project.Controllers
{
    public class MidtermController : Controller
    {
        // GET: Midterm
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TakeTest()
        {
            return View(GetQuestions());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeTest(List<TestQuestion> answers)
        {
            List<TestQuestion> questions = GetQuestions();

            foreach(TestQuestion tq in questions)
            {
                tq.Answer = answers[tq.ID - 1].Answer;
            }

            if (!ModelState.IsValid)
                return View(questions);

            TempData["TestData"] = questions;
            return RedirectToAction("DisplayResults");

        }

        public ActionResult DisplayResults()
        {
            List<TestQuestion> testdata = (List<TestQuestion>)TempData["TestData"];
            return View(testdata);
        }


        List<TestQuestion> GetQuestions()
        {
            List<jsonData> data;
            List<TestQuestion> questions = new List<TestQuestion>();
            JavaScriptSerializer jss = new JavaScriptSerializer(new SimpleTypeResolver());

            string json = System.IO.File.ReadAllText(HttpContext.Server.MapPath("/JSON/Midterm.json"));

            data = jss.Deserialize<List<jsonData>>(json);

            foreach(jsonData jd in data)
            {
                TestQuestion tq;
                if(jd.type == "TrueFalseQuestion")
                {
                    tq = new TrueFalseQuestion();
                }
                else if(jd.type == "ShortAnswerQuestion")
                {
                    tq = new ShortAnswerQuestion();
                }
                else if(jd.type == "LongAnswerQuestion")
                {
                    tq = new LongAnswerQuestion();
                }
                else
                {
                    tq = new MultipleChoiceQuestion();
                    ((MultipleChoiceQuestion)tq).Choices = jd.choices;
                }
                tq.ID = jd.id;
                tq.Question = jd.question;
                questions.Add(tq);
            }


            return (questions == null ? new List<TestQuestion>() : questions);
        }
    }

    public class jsonData
    {
        public int id { get; set; }
        public string type { get; set; }
        public string question { get; set; }
        public List<string> choices { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        TestDbContext db = new TestDbContext();

        public ActionResult Index()
        {
            // передать в View все тесты в алфавитном порядке:
            ViewBag.Tests = db.Tests.OrderBy(pp => pp.Name);
            return View();
        }

        /// <summary>
        /// Передать опросник для прохождения/редактирования
        /// </summary>
        /// <param name="testId">Id опросника в таблице бд Tests</param>
        public ActionResult PassTest(int testId)
        {
            string userIP = Request.UserHostAddress;// для идентификации пользователя

            // загрузить или создать фактический опросник:
            var ft = db.FactTests.FirstOrDefault(pp => pp.TestId == testId && pp.UserIP == userIP);
            if (ft == null)
            {
                ft = new FactTest() { UserIP = userIP, TestId = testId };
                db.FactTests.Add(ft);
                db.SaveChanges();
            }

            // передать данные о опроснике и вопросы в View:
            ViewBag.ftId = ft.Id;
            ViewBag.testName = db.Tests.First(pp => pp.Id == testId).Name;
            ViewBag.Questions = (from q in db.Questions.Include("Variants") where q.TestId == testId orderby q.Num select q);

            // передать ответы пользователя в View:
            if (ft.CheckAnswers != null)// ответы на вопросы с выбором варианта/ов
                ViewBag.CheckAnswers = ft.CheckAnswers.ToDictionary(pp => pp.VariantId, pp => pp.QuestionId);
            else ViewBag.CheckAnswers = new Dictionary<int, int>();

            if (ft.TextAnswers != null)// ответы на вопросы с вводом текста
                ViewBag.TextAnswers = ft.TextAnswers.ToDictionary(pp => pp.QuestionId, pp => pp.Text);
            else ViewBag.TextAnswers = new Dictionary<int, string>();

            return View();
        }
        /// <summary>
        /// Обработать заполненную форму опросника
        /// </summary>
        /// <param name="ftId">Id фактического опросника в таблице бд FactTests</param>
        /// <param name="checkAnswers">словарь отмеченных вариантов на вопросы с выбором</param>
        /// <param name="textAnswers">словарь ответов на вопросы с вводом текста</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PassTest(int ftId, Dictionary<string, List<int>> checkAnswers = null, Dictionary<string, string> textAnswers = null)
        {
            var ft = db.FactTests.Find(ftId);
            if (ft.CheckAnswers != null) db.CheckAnswers.RemoveRange(ft.CheckAnswers); // удаляем предыдущие ответы на вопросы с выбором
            
            // добавляем ответы на вопросы с выбором в бд CheckAnswers:
            if (!checkAnswers.ContainsKey("controller"))//игнор некорректной привязки (при пустом checkAnswers)
                foreach (var c in checkAnswers)// c.Key - Id вопроса в таблице бд Questions
                    foreach (var cv in c.Value)// c.Value - список из Id выбранных пользователем вариантов (по таблице бд Variants)
                        db.CheckAnswers.Add(new CheckAnswer() { FactTestId = ft.Id, QuestionId = int.Parse(c.Key), VariantId = cv });

            
            if (ft.TextAnswers != null) db.TextAnswers.RemoveRange(ft.TextAnswers);// удаляем предыдущие ответы на вопросы с вводом текста

            // добавляем ответы на вопросы с вводом текста в бд TextAnswers:
            if (!textAnswers.ContainsKey("controller"))//игнор некорректной привязки (при пустом textAnswers)
                foreach (var t in textAnswers)
                    db.TextAnswers.Add(new TextAnswer() { FactTestId = ft.Id, QuestionId = int.Parse(t.Key), Text = t.Value });

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
using System.Web.Mvc;

namespace QuizPlatform.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {                  
      return View();
    }       

    //private void AddTestData()
    //{
    //  QuizContext db = new QuizContext();

    //  Question questionAnswer = new Question();
    //  questionAnswer.Answer = "asd";
    //  questionAnswer.Category = Categories.English;
    //  questionAnswer.Question = "q1";
    //  questionAnswer.Set = Sets.First;

    //  Question questionAnswer2 = new Question();
    //  questionAnswer2.Answer = "we use ‘f’ or ‘F’";
    //  questionAnswer2.Category = Categories.DotNet;
    //  questionAnswer2.Question = "How to write float";
    //  questionAnswer2.Set = Sets.First;

    //  Question questionAnswer3 = new Question();
    //  questionAnswer3.Answer = "we use ‘m’ or ‘M’";
    //  questionAnswer3.Category = Categories.DotNet;
    //  questionAnswer3.Question = "How to write decimal";
    //  questionAnswer3.Set = Sets.First;

    //  db.QuestionAnswers.Add(questionAnswer);
    //  db.QuestionAnswers.Add(questionAnswer2);
    //  db.QuestionAnswers.Add(questionAnswer3);

    //  db.SaveChanges();
    //}
  }
}
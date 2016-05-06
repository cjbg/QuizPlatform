using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QuizPlatform.Helpers;
using QuizPlatform.Models;
using QuizPlatform.Resources;
using QuizPlatform.Services.Interfaces;

namespace QuizPlatform.Controllers
{
  [Authorize]
  public class QuizStartController : Controller
  {
    private readonly QuizContext _db = new QuizContext();
    private readonly IQuizManager _quizManager;

    public QuizStartController(IQuizManager quizManager)
    {
      _quizManager = quizManager;
    }

    // GET: /QuizStart/
    public ActionResult Index()
    {
      return View(_db.Quizzes.ToList());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _db.Dispose();
      }

      base.Dispose(disposing);
    }

    public ActionResult Start(int id)
    {
      var quiz = _db.Quizzes.Find(id);

      var questions = _db.Questions
        .Where(x => x.QuizId == id)
        .ToList();

      _quizManager.Shuffle(ref questions);

      var domainQuestions = MapperConfig.Mapper
        .Map<List<Question>, List<Models.Domain.Question>>(questions);

      HttpContext.Cache[Constants.CacheQuestions + User.Identity] = domainQuestions;

      ViewBag.QuestionCounter = 0;

      //TODO: Take first question and load answers with ajax 
      //TODO: After answering the question set repetitonNumber with ajax

      return View(quiz);
    }

    public ActionResult GetQuestion(string questionCounter)
    {
      List<Models.Domain.Question> questions =
        (HttpContext.Cache[Constants.CacheQuestions + User.Identity]
          as List<Models.Domain.Question>);

      Guard.NotNull(questions, () => questions);
      Models.Domain.Question question = questions[Convert.ToInt32(questionCounter)];

      return Json(question, JsonRequestBehavior.AllowGet);
    }
  }
}

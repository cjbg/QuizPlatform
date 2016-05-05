using System.Linq;
using System.Web.Mvc;
using QuizPlatform.Models;
using QuizPlatform.Services.Interfaces;

namespace QuizPlatform.Controllers
{
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

      //TODO: add automapper

      return View(quiz);
    }
  }
}

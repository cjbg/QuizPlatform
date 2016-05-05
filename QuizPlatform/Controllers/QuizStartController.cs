using System.Linq;
using System.Web.Mvc;
using QuizPlatform.Models;

namespace QuizPlatform.Controllers
{
  public class QuizStartController : Controller
  {
    private readonly QuizContext _db = new QuizContext();

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
      return View(quiz);
    }
  }
}

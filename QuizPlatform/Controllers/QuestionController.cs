using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizPlatform.Models;

namespace QuizPlatform.Controllers
{
  public class QuestionController : Controller
  {
    private readonly QuizContext _db = new QuizContext();

    // GET: /Question/
    public ActionResult Index(int id)
    {
      var questions = _db.Questions.Where(x => x.QuizId == id).ToList();
      ViewBag.QuizId = id;

      return View(questions);
    }

    // GET: /Question/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Question question = _db.Questions.Find(id);
      if (question == null)
      {
        return HttpNotFound();
      }

      return View(question);
    }

    // GET: /Question/Create
    public ActionResult Create(int id)
    {
      Question question = new Question();
      question.QuizId = id;

      return View(question);
    }

    // POST: /Question/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,QuizId,Name")] Question question)
    {
      if (ModelState.IsValid)
      {
        _db.Questions.Add(question);
        _db.SaveChanges();

        return RedirectToAction("Index", new { id = question.QuizId });
      }

      return View(question);
    }

    // GET: /Question/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Question question = _db.Questions.Find(id);
      if (question == null)
      {
        return HttpNotFound();
      }

      return View(question);
    }

    // POST: /Question/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,QuizId,Name")] Question question)
    {
      if (ModelState.IsValid)
      {
        _db.Entry(question).State = EntityState.Modified;
        _db.SaveChanges();

        return RedirectToAction("Index", new { question.QuizId });
      }
      return View(question);
    }

    // GET: /Question/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Question question = _db.Questions.Find(id);
      if (question == null)
      {
        return HttpNotFound();
      }
      return View(question);
    }

    // POST: /Question/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Question question = _db.Questions.Find(id);
      _db.Questions.Remove(question);
      _db.SaveChanges();

      return RedirectToAction("Index", new { id = question.QuizId });
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}

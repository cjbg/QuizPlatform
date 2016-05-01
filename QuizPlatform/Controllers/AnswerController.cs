using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizPlatform.Models;

namespace QuizPlatform.Controllers
{
  public class AnswerController : Controller
  {
    private readonly QuizContext _db = new QuizContext();

    // GET: /Answer/
    public ActionResult Index(int id)
    {
      var answers = _db.Answers.Where(x => x.QuestionId == id).ToList();
      ViewBag.QuestionId = id;

      return View(answers);
    }

    // GET: /Answer/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Answer answer = _db.Answers.Find(id);
      if (answer == null)
      {
        return HttpNotFound();
      }
      return View(answer);
    }

    // GET: /Answer/Create
    public ActionResult Create(int id)
    {
      Answer answer = new Answer();
      answer.QuestionId = id;

      return View(answer);
    }

    // POST: /Answer/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,QuestionId,Name")] Answer answer)
    {
      if (ModelState.IsValid)
      {
        _db.Answers.Add(answer);
        _db.SaveChanges();

        return RedirectToAction("Index", new { id = answer.QuestionId });
      }

      return View(answer);
    }

    // GET: /Answer/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Answer answer = _db.Answers.Find(id);
      if (answer == null)
      {
        return HttpNotFound();
      }
      return View(answer);
    }

    // POST: /Answer/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,QuestionId,Name")] Answer answer)
    {
      if (ModelState.IsValid)
      {
        _db.Entry(answer).State = EntityState.Modified;
        _db.SaveChanges();

        return RedirectToAction("Index", new { id = answer.QuestionId });
      }
      return View(answer);
    }

    // GET: /Answer/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Answer answer = _db.Answers.Find(id);
      if (answer == null)
      {
        return HttpNotFound();
      }

      return View(answer);
    }

    // POST: /Answer/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Answer answer = _db.Answers.Find(id);
      _db.Answers.Remove(answer);
      _db.SaveChanges();

      return RedirectToAction("Index", new { id = answer.QuestionId});
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

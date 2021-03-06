﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QuizPlatform.Models;
using QuizPlatform.Models.Domain;

namespace QuizPlatform.Controllers
{
  public class QuizController : Controller
  {
    private readonly QuizContext _db = new QuizContext();

    // GET: /Quiz/
    public ActionResult Index()
    {
      return View(_db.Quizzes.ToList());
    }

    // GET: /Quiz/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Quiz quiz = _db.Quizzes.Find(id);
      if (quiz == null)
      {
        return HttpNotFound();
      }
      return View(quiz);
    }

    // GET: /Quiz/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: /Quiz/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Name,Category,Set")] Quiz quiz)
    {
      if (ModelState.IsValid)
      {
        _db.Quizzes.Add(quiz);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(quiz);
    }

    // GET: /Quiz/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Quiz quiz = _db.Quizzes.Find(id);
      if (quiz == null)
      {
        return HttpNotFound();
      }
      return View(quiz);
    }

    // POST: /Quiz/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Name,Category,Set")] Quiz quiz)
    {
      if (ModelState.IsValid)
      {
        _db.Entry(quiz).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(quiz);
    }

    // GET: /Quiz/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Quiz quiz = _db.Quizzes.Find(id);
      if (quiz == null)
      {
        return HttpNotFound();
      }
      return View(quiz);
    }

    // POST: /Quiz/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Quiz quiz = _db.Quizzes.Find(id);
      _db.Quizzes.Remove(quiz);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _db.Dispose();
      }
      base.Dispose(disposing);
    }

    public ActionResult ShowQuestions(int id, string name)
    {
      MySession.Current.QuizName = name;
      return RedirectToAction("Index", "Question", new {id});
    }
  }
}

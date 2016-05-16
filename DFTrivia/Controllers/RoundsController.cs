using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DFTrivia.Models;

namespace DFTrivia.Controllers
{
    public class RoundsController : Controller
    {
        private TriviaDBEntities db = new TriviaDBEntities();

        // GET: Rounds
        public ActionResult Index()
        {
            var rounds = db.Rounds.Include(r => r.Question).Include(r => r.User);
            return View(rounds.ToList());
        }

        // GET: Rounds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            return View(round);
        }

        // GET: Rounds/Create
        public ActionResult Create()
        {
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Question1");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Rounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoundID,Rounds,QuestionID,UserID,GameType")] Round round)
        {
            if (ModelState.IsValid)
            {
                db.Rounds.Add(round);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Question1", round.QuestionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", round.UserID);
            return View(round);
        }

        // GET: Rounds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Question1", round.QuestionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", round.UserID);
            return View(round);
        }

        // POST: Rounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoundID,Rounds,QuestionID,UserID,GameType")] Round round)
        {
            if (ModelState.IsValid)
            {
                db.Entry(round).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Question1", round.QuestionID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", round.UserID);
            return View(round);
        }

        // GET: Rounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            return View(round);
        }

        // POST: Rounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Round round = db.Rounds.Find(id);
            db.Rounds.Remove(round);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ComediesController : Controller
    {
        private Training_12DecMumbaiEntities9 db = new Training_12DecMumbaiEntities9();

        // GET: Comedies
        [HandleError]
        public ActionResult Index()
        {
            return View(db.Comedies.ToList());
        }

        // GET: Comedies/Details/5
        [HandleError]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comedy comedy = db.Comedies.Find(id);
            if (comedy == null)
            {
                return HttpNotFound();
            }
            return View(comedy);
        }

        // GET: Comedies/Create
        [HandleError]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comedies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieName,ReleaseDate,Description")] Comedy comedy)
        {
            if (ModelState.IsValid)
            {
                db.Comedies.Add(comedy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comedy);
        }

        // GET: Comedies/Edit/5
        [HandleError]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comedy comedy = db.Comedies.Find(id);
            if (comedy == null)
            {
                return HttpNotFound();
            }
            return View(comedy);
        }

        // POST: Comedies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieName,ReleaseDate,Description")] Comedy comedy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comedy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comedy);
        }

        // GET: Comedies/Delete/5
        [HandleError]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comedy comedy = db.Comedies.Find(id);
            if (comedy == null)
            {
                return HttpNotFound();
            }
            return View(comedy);
        }

        // POST: Comedies/Delete/5
        [HandleError]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Comedy comedy = db.Comedies.Find(id);
            db.Comedies.Remove(comedy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HandleError]
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

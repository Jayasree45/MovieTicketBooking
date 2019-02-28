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
    public class HorrorsController : Controller
    {
        private ActionContext db = new ActionContext();

        // GET: Horrors
        [HandleError]
        public ActionResult Index()
        {
            return View(db.Horrors.ToList());
        }

        // GET: Horrors/Details/5
        [HandleError]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horror horror = db.Horrors.Find(id);
            if (horror == null)
            {
                return HttpNotFound();
            }
            return View(horror);
        }

        // GET: Horrors/Create
        [HandleError]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horrors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieName,ReleaseDate,Description")] Horror horror)
        {
            if (ModelState.IsValid)
            {
                db.Horrors.Add(horror);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horror);
        }

        // GET: Horrors/Edit/5
        [HandleError]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horror horror = db.Horrors.Find(id);
            if (horror == null)
            {
                return HttpNotFound();
            }
            return View(horror);
        }

        // POST: Horrors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieName,ReleaseDate,Description")] Horror horror)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horror).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horror);
        }

        // GET: Horrors/Delete/5
        [HandleError]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horror horror = db.Horrors.Find(id);
            if (horror == null)
            {
                return HttpNotFound();
            }
            return View(horror);
        }

        // POST: Horrors/Delete/5
        [HandleError]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Horror horror = db.Horrors.Find(id);
            db.Horrors.Remove(horror);
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

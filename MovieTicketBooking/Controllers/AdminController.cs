using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MovieTicketBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        private ActionContext db = new ActionContext();
        // GET: Admin
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HandleError]
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string UserName = form["txtEmail"];
            string email = form["txtEmail"];
            string pwd = form["txtPassword"];

            //create default user 
            var user = new ApplicationUser();
            user.Email = email;
            user.UserName = UserName;
            string password = pwd;

            var newuser = UserManager.Create(user, pwd);
            UserManager.AddToRolesAsync("Employee");
            //   Session["Abc"] = newuser;
            return View();
        }
        [HandleError]
        public ActionResult CreateRole()
        {
            return View();
        }
        [HandleError]
        [HttpPost]
        public ActionResult CreateRole(FormCollection form)
        {
            string rolename = form["RoleName"];
            return View();
        }
        [HandleError]
        public ActionResult AssignRole()
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();

            return View();
        }
        [HandleError]
        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string username = form["txtUserName"];
            string rolename = form["RoleName"];
            ApplicationUser user = context.Users.Where(u => u.Email.Equals(username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(user.Id, rolename);

            return View("Index");
        }



        //    //action
        //    [HandleError]
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Actions/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HandleError]
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "MovieName,ReleaseDate,Description")] Models.Action action)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Actions.Add(action);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(action);
        //    }

        //    // GET: Actions/Edit/5
        //    [HandleError]
        //    public ActionResult Edit(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Models.Action action = db.Actions.Find(id);
        //        if (action == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(action);
        //    }

        //    // POST: Actions/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HandleError]
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "MovieName,ReleaseDate,Description")] Models.Action action)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(action).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(action);
        //    }

        //    // GET: Actions/Delete/5
        //    [HandleError]
        //    public ActionResult Delete(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Models.Action action = db.Actions.Find(id);
        //        if (action == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(action);
        //    }

        //    // POST: Actions/Delete/5
        //    [HandleError]
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(string id)
        //    {
        //        Models.Action action = db.Actions.Find(id);
        //        db.Actions.Remove(action);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    [HandleError]
        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}
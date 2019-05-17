using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Petnb_MVC5.Models;

namespace Petnb_MVC5.Controllers
{
    public class SitterUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SitterUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: SitterUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SitterUser sitterUser = db.SitterUsers.Find(id);
            if (sitterUser == null)
            {
                return HttpNotFound();
            }
            return View(sitterUser);
        }

        // GET: SitterUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SitterUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Rating,Address,Age,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,SitterUserId")] SitterUser sitterUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(sitterUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sitterUser);
        }

        // GET: SitterUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SitterUser sitterUser = db.SitterUsers.Find(id);
            if (sitterUser == null)
            {
                return HttpNotFound();
            }
            return View(sitterUser);
        }

        // POST: SitterUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Rating,Address,Age,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,SitterUserId")] SitterUser sitterUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sitterUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sitterUser);
        }

        // GET: SitterUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SitterUser sitterUser = db.SitterUsers.Find(id);
            if (sitterUser == null)
            {
                return HttpNotFound();
            }
            return View(sitterUser);
        }

        // POST: SitterUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SitterUser sitterUser = db.SitterUsers.Find(id);
            db.Users.Remove(sitterUser);
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

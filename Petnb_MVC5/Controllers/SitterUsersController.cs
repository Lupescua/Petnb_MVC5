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
            return View(db.SitterUsers.ToList());
        }

        // GET: SitterUsers/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include = "SitterUserId")] SitterUser sitterUser)
        {
            if (ModelState.IsValid)
            {
                db.SitterUsers.Add(sitterUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sitterUser);
        }

        // GET: SitterUsers/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "SitterUserId")] SitterUser sitterUser)
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
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
        {
            SitterUser sitterUser = db.SitterUsers.Find(id);
            db.SitterUsers.Remove(sitterUser);
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

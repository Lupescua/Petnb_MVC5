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
    public class OwnerUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OwnerUsers
        public ActionResult Index()
        {
            return View(db.OwnerUsers.ToList());
        }

        // GET: OwnerUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerUser ownerUser = db.OwnerUsers.Find(id);
            if (ownerUser == null)
            {
                return HttpNotFound();
            }
            return View(ownerUser);
        }

        // GET: OwnerUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OwnerUserId")] OwnerUser ownerUser)
        {
            if (ModelState.IsValid)
            {
                db.OwnerUsers.Add(ownerUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ownerUser);
        }

        // GET: OwnerUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerUser ownerUser = db.OwnerUsers.Find(id);
            if (ownerUser == null)
            {
                return HttpNotFound();
            }
            return View(ownerUser);
        }

        // POST: OwnerUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OwnerUserId")] OwnerUser ownerUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ownerUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ownerUser);
        }

        // GET: OwnerUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerUser ownerUser = db.OwnerUsers.Find(id);
            if (ownerUser == null)
            {
                return HttpNotFound();
            }
            return View(ownerUser);
        }

        // POST: OwnerUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OwnerUser ownerUser = db.OwnerUsers.Find(id);
            db.OwnerUsers.Remove(ownerUser);
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

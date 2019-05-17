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
    public class PetSitterOffersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PetSitterOffers
        public ActionResult Index()
        {
            var petSitterOffers = db.PetSitterOffers.Include(p => p.OwnerUser);
            return View(petSitterOffers.ToList());
        }

        // GET: PetSitterOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetSitterOffer petSitterOffer = db.PetSitterOffers.Find(id);
            if (petSitterOffer == null)
            {
                return HttpNotFound();
            }
            return View(petSitterOffer);
        }

        // GET: PetSitterOffers/Create
        public ActionResult Create()
        {
            ViewBag.OwnerUserId = new SelectList(db.OwnerUsers, "Id", "FullName");
            return View();
        }

        // POST: PetSitterOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetSitterOfferId,Heading,Content,Location,StartOfSit,EndOfSit,ExpectedSalary,OwnerUserId")] PetSitterOffer petSitterOffer)
        {
            if (ModelState.IsValid)
            {
                db.PetSitterOffers.Add(petSitterOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerUserId = new SelectList(db.OwnerUsers, "Id", "FullName", petSitterOffer.OwnerUserId);
            return View(petSitterOffer);
        }

        // GET: PetSitterOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetSitterOffer petSitterOffer = db.PetSitterOffers.Find(id);
            if (petSitterOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerUserId = new SelectList(db.OwnerUsers, "Id", "FullName", petSitterOffer.OwnerUserId);
            return View(petSitterOffer);
        }

        // POST: PetSitterOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetSitterOfferId,Heading,Content,Location,StartOfSit,EndOfSit,ExpectedSalary,OwnerUserId")] PetSitterOffer petSitterOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petSitterOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerUserId = new SelectList(db.OwnerUsers, "Id", "FullName", petSitterOffer.OwnerUserId);
            return View(petSitterOffer);
        }

        // GET: PetSitterOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetSitterOffer petSitterOffer = db.PetSitterOffers.Find(id);
            if (petSitterOffer == null)
            {
                return HttpNotFound();
            }
            return View(petSitterOffer);
        }

        // POST: PetSitterOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetSitterOffer petSitterOffer = db.PetSitterOffers.Find(id);
            db.PetSitterOffers.Remove(petSitterOffer);
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

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
    public class PetOffersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PetOffers
        public ActionResult Index()
        {
            var petOffers = db.PetOffers.Include(p => p.SitterUser);
            return View(petOffers.ToList());
        }

        // GET: PetOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetOffer petOffer = db.PetOffers.Find(id);
            if (petOffer == null)
            {
                return HttpNotFound();
            }
            return View(petOffer);
        }

        // GET: PetOffers/Create
        public ActionResult Create()
        {
            ViewBag.SitterUserId = new SelectList(db.SitterUsers, "Id", "FullName");
            return View();
        }

        // POST: PetOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetOfferId,Heading,Content,Reward,PetLocation,PetNeeds,StartOfSit,EndOfSit,PetId,SitterUserId")] PetOffer petOffer)
        {
            if (ModelState.IsValid)
            {
                db.PetOffers.Add(petOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SitterUserId = new SelectList(db.SitterUsers, "Id", "FullName", petOffer.SitterUserId);
            return View(petOffer);
        }

        // GET: PetOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetOffer petOffer = db.PetOffers.Find(id);
            if (petOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SitterUserId = new SelectList(db.SitterUsers, "Id", "FullName", petOffer.SitterUserId);
            return View(petOffer);
        }

        // POST: PetOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetOfferId,Heading,Content,Reward,PetLocation,PetNeeds,StartOfSit,EndOfSit,PetId,SitterUserId")] PetOffer petOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SitterUserId = new SelectList(db.SitterUsers, "Id", "FullName", petOffer.SitterUserId);
            return View(petOffer);
        }

        // GET: PetOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetOffer petOffer = db.PetOffers.Find(id);
            if (petOffer == null)
            {
                return HttpNotFound();
            }
            return View(petOffer);
        }

        // POST: PetOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetOffer petOffer = db.PetOffers.Find(id);
            db.PetOffers.Remove(petOffer);
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

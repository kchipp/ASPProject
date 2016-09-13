using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPProject.Models;

namespace ASPProject.Controllers
{
    public class AspNetUserPaymentJunctionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AspNetUserPaymentJunctions
        public ActionResult Index()
        {
            var aspUserPaymentJunction = db.AspUserPaymentJunction.Include(a => a.AspNetUsers).Include(a => a.Payments);
            return View(aspUserPaymentJunction.ToList());
        }

        // GET: AspNetUserPaymentJunctions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserPaymentJunction aspNetUserPaymentJunction = db.AspUserPaymentJunction.Find(id);
            if (aspNetUserPaymentJunction == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserPaymentJunction);
        }

        // GET: AspNetUserPaymentJunctions/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.PaymentId = new SelectList(db.Payment, "PaymentId", "CardType");
            return View();
        }

        // POST: AspNetUserPaymentJunctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserPaymentId,UserId,PaymentId")] AspNetUserPaymentJunction aspNetUserPaymentJunction)
        {
            if (ModelState.IsValid)
            {
                db.AspUserPaymentJunction.Add(aspNetUserPaymentJunction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", aspNetUserPaymentJunction.UserId);
            ViewBag.PaymentId = new SelectList(db.Payment, "PaymentId", "CardType", aspNetUserPaymentJunction.PaymentId);
            return View(aspNetUserPaymentJunction);
        }

        // GET: AspNetUserPaymentJunctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserPaymentJunction aspNetUserPaymentJunction = db.AspUserPaymentJunction.Find(id);
            if (aspNetUserPaymentJunction == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", aspNetUserPaymentJunction.UserId);
            ViewBag.PaymentId = new SelectList(db.Payment, "PaymentId", "CardType", aspNetUserPaymentJunction.PaymentId);
            return View(aspNetUserPaymentJunction);
        }

        // POST: AspNetUserPaymentJunctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserPaymentId,UserId,PaymentId")] AspNetUserPaymentJunction aspNetUserPaymentJunction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUserPaymentJunction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", aspNetUserPaymentJunction.UserId);
            ViewBag.PaymentId = new SelectList(db.Payment, "PaymentId", "CardType", aspNetUserPaymentJunction.PaymentId);
            return View(aspNetUserPaymentJunction);
        }

        // GET: AspNetUserPaymentJunctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserPaymentJunction aspNetUserPaymentJunction = db.AspUserPaymentJunction.Find(id);
            if (aspNetUserPaymentJunction == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserPaymentJunction);
        }

        // POST: AspNetUserPaymentJunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetUserPaymentJunction aspNetUserPaymentJunction = db.AspUserPaymentJunction.Find(id);
            db.AspUserPaymentJunction.Remove(aspNetUserPaymentJunction);
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

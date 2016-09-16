using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPProject.Models;
using Microsoft.AspNet.Identity;

namespace ASPProject.Controllers
{
    public class PaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payments
        public ActionResult Index()
        {
            return View(db.Payment.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentId,PaymentMethod,CardType,CardNumber,ExpirationDate,SecurityCode")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payment.Add(payment);
                db.SaveChanges();


                
                //var userId = User.Identity.GetUserId();
                //var serviceId = db.Service.Where(x => x.UserId == userId).FirstOrDefault().ServiceId;
                


                return RedirectToAction("GetDetails","Services");
            }

            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentId,PaymentMethod,CardType,CardNumber,ExpirationDate,SecurityCode")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payment.Find(id);
            db.Payment.Remove(payment);
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

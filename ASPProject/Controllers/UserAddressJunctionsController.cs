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
    public class UserAddressJunctionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserAddressJunctions
        public ActionResult Index()
        {
            var userAddressJunction = db.UserAddressJunction.Include(u => u.Addresses).Include(u => u.AspNetUsers);
            return View(userAddressJunction.ToList());
        }

        // GET: UserAddressJunctions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAddressJunction userAddressJunction = db.UserAddressJunction.Find(id);
            if (userAddressJunction == null)
            {
                return HttpNotFound();
            }
            return View(userAddressJunction);
        }

        // GET: UserAddressJunctions/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "Address1");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: UserAddressJunctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserAddressId,UserId,AddressId")] UserAddressJunction userAddressJunction)
        {
            if (ModelState.IsValid)
            {
                db.UserAddressJunction.Add(userAddressJunction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "Address1", userAddressJunction.AddressId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userAddressJunction.UserId);
            return View(userAddressJunction);
        }

        // GET: UserAddressJunctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAddressJunction userAddressJunction = db.UserAddressJunction.Find(id);
            if (userAddressJunction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "Address1", userAddressJunction.AddressId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userAddressJunction.UserId);
            return View(userAddressJunction);
        }

        // POST: UserAddressJunctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserAddressId,UserId,AddressId")] UserAddressJunction userAddressJunction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAddressJunction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "Address1", userAddressJunction.AddressId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userAddressJunction.UserId);
            return View(userAddressJunction);
        }

        // GET: UserAddressJunctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAddressJunction userAddressJunction = db.UserAddressJunction.Find(id);
            if (userAddressJunction == null)
            {
                return HttpNotFound();
            }
            return View(userAddressJunction);
        }

        // POST: UserAddressJunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAddressJunction userAddressJunction = db.UserAddressJunction.Find(id);
            db.UserAddressJunction.Remove(userAddressJunction);
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

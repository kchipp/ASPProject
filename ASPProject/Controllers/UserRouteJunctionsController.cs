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
    public class UserRouteJunctionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserRouteJunctions
        public ActionResult Index()
        {
            var userRouteJunction = db.UserRouteJunction.Include(u => u.AspNetUsers).Include(u => u.Route);
            return View(userRouteJunction.ToList());
        }

        // GET: UserRouteJunctions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRouteJunction userRouteJunction = db.UserRouteJunction.Find(id);
            if (userRouteJunction == null)
            {
                return HttpNotFound();
            }
            return View(userRouteJunction);
        }

        // GET: UserRouteJunctions/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.RouteId = new SelectList(db.Route, "RouteId", "UserId");
            return View();
        }

        // POST: UserRouteJunctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserRouteId,RouteId,UserId")] UserRouteJunction userRouteJunction)
        {
            if (ModelState.IsValid)
            {
                db.UserRouteJunction.Add(userRouteJunction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userRouteJunction.UserId);
            ViewBag.RouteId = new SelectList(db.Route, "RouteId", "UserId", userRouteJunction.RouteId);
            return View(userRouteJunction);
        }

        // GET: UserRouteJunctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRouteJunction userRouteJunction = db.UserRouteJunction.Find(id);
            if (userRouteJunction == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userRouteJunction.UserId);
            ViewBag.RouteId = new SelectList(db.Route, "RouteId", "UserId", userRouteJunction.RouteId);
            return View(userRouteJunction);
        }

        // POST: UserRouteJunctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserRouteId,RouteId,UserId")] UserRouteJunction userRouteJunction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRouteJunction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", userRouteJunction.UserId);
            ViewBag.RouteId = new SelectList(db.Route, "RouteId", "UserId", userRouteJunction.RouteId);
            return View(userRouteJunction);
        }

        // GET: UserRouteJunctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRouteJunction userRouteJunction = db.UserRouteJunction.Find(id);
            if (userRouteJunction == null)
            {
                return HttpNotFound();
            }
            return View(userRouteJunction);
        }

        // POST: UserRouteJunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRouteJunction userRouteJunction = db.UserRouteJunction.Find(id);
            db.UserRouteJunction.Remove(userRouteJunction);
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

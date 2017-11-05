using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarHailingApp.Models;

namespace CarHailingApp.Controllers
{
    public class PassengersController : Controller
    {
        private RideAppEntities db = new RideAppEntities();

        // GET: Passengers
         [Authorize(Roles = "Admin,Passenger")]
  
        public ActionResult Index()
        {
            return View(db.tblPassengers.ToList());
        }

        // GET: Passengers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPassenger tblPassenger = db.tblPassengers.Find(id);
            if (tblPassenger == null)
            {
                return HttpNotFound();
            }
            return View(tblPassenger);
        }

        // GET: Passengers/Create
         [Authorize(Roles = "Admin")]
  
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PId,Name,ConatctNo")] tblPassenger tblPassenger)
        {
            if (ModelState.IsValid)
            {
                db.tblPassengers.Add(tblPassenger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPassenger);
        }

        // GET: Passengers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPassenger tblPassenger = db.tblPassengers.Find(id);
            if (tblPassenger == null)
            {
                return HttpNotFound();
            }
            return View(tblPassenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PId,Name,ConatctNo")] tblPassenger tblPassenger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPassenger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPassenger);
        }

        // GET: Passengers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPassenger tblPassenger = db.tblPassengers.Find(id);
            if (tblPassenger == null)
            {
                return HttpNotFound();
            }
            return View(tblPassenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPassenger tblPassenger = db.tblPassengers.Find(id);
            db.tblPassengers.Remove(tblPassenger);
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

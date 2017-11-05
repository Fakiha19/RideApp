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
    [Authorize(Roles = "Admin")]
  
    public class tblRidesController : Controller
    {
        private RideAppEntities db = new RideAppEntities();

        // GET: tblRides
        public ActionResult Index()
        {
            var tblRides = db.tblRides.Include(t => t.tblDriver).Include(t => t.tblPassenger);
            return View(tblRides.ToList());
        }

        // GET: tblRides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRide tblRide = db.tblRides.Find(id);
            if (tblRide == null)
            {
                return HttpNotFound();
            }
            return View(tblRide);
        }

        // GET: tblRides/Create
        public ActionResult Create()
        {
            ViewBag.Driver = new SelectList(db.tblDrivers, "DId", "Name");
            ViewBag.Passenger = new SelectList(db.tblPassengers, "PId", "Name");
            return View();
        }

        // POST: tblRides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RId,Driver,Passenger,RequestLocation,Destination,vehicle,Rent,shift")] tblRide tblRide)
        {
            if (ModelState.IsValid)
            {
                db.tblRides.Add(tblRide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Driver = new SelectList(db.tblDrivers, "DId", "Name", tblRide.Driver);
            ViewBag.Passenger = new SelectList(db.tblPassengers, "PId", "Name", tblRide.Passenger);
            return View(tblRide);
        }

        // GET: tblRides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRide tblRide = db.tblRides.Find(id);
            if (tblRide == null)
            {
                return HttpNotFound();
            }
            ViewBag.Driver = new SelectList(db.tblDrivers, "DId", "Name", tblRide.Driver);
            ViewBag.Passenger = new SelectList(db.tblPassengers, "PId", "Name", tblRide.Passenger);
            return View(tblRide);
        }

        // POST: tblRides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RId,Driver,Passenger,RequestLocation,Destination,vehicle,Rent,shift")] tblRide tblRide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Driver = new SelectList(db.tblDrivers, "DId", "Name", tblRide.Driver);
            ViewBag.Passenger = new SelectList(db.tblPassengers, "PId", "Name", tblRide.Passenger);
            return View(tblRide);
        }

        // GET: tblRides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRide tblRide = db.tblRides.Find(id);
            if (tblRide == null)
            {
                return HttpNotFound();
            }
            return View(tblRide);
        }

        // POST: tblRides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRide tblRide = db.tblRides.Find(id);
            db.tblRides.Remove(tblRide);
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

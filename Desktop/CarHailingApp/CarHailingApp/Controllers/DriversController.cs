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
    [Authorize]
    public class DriversController : Controller
    {
        private RideAppEntities db = new RideAppEntities();

        // GET: Drivers
          [Authorize(Roles = "Admin,Driver")]
  
        public ActionResult Index()
        {
            return View(db.tblDrivers.ToList());
        }

        // GET: Drivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDriver tblDriver = db.tblDrivers.Find(id);
            if (tblDriver == null)
            {
                return HttpNotFound();
            }
            return View(tblDriver);
        }

        // GET: Drivers/Create
   [Authorize(Roles = "Admin")]
  
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DId,Name,Salary,Residence,ContactNo")] tblDriver tblDriver)
        {
            if (ModelState.IsValid)
            {
                db.tblDrivers.Add(tblDriver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDriver);
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDriver tblDriver = db.tblDrivers.Find(id);
            if (tblDriver == null)
            {
                return HttpNotFound();
            }
            return View(tblDriver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DId,Name,Salary,Residence,ContactNo")] tblDriver tblDriver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDriver);
        }

        // GET: Drivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDriver tblDriver = db.tblDrivers.Find(id);
            if (tblDriver == null)
            {
                return HttpNotFound();
            }
            return View(tblDriver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDriver tblDriver = db.tblDrivers.Find(id);
            db.tblDrivers.Remove(tblDriver);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drones;
using Drones.Models;

namespace Drones.Controllers
{
    public class StoragePointsController : Controller
    {
        private DronesContext db = new DronesContext();

        // GET: StoragePoints
        public ActionResult Index()
        {
            return View(db.StoragePoints.ToList());
        }

        // GET: StoragePoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoragePoint storagePoint = db.StoragePoints.Find(id);
            if (storagePoint == null)
            {
                return HttpNotFound();
            }
            return View(storagePoint);
        }

        // GET: StoragePoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoragePoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address")] StoragePoint storagePoint)
        {
            if (ModelState.IsValid)
            {
                db.StoragePoints.Add(storagePoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storagePoint);
        }

        // GET: StoragePoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoragePoint storagePoint = db.StoragePoints.Find(id);
            if (storagePoint == null)
            {
                return HttpNotFound();
            }
            return View(storagePoint);
        }

        // POST: StoragePoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address")] StoragePoint storagePoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storagePoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storagePoint);
        }

        // GET: StoragePoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoragePoint storagePoint = db.StoragePoints.Find(id);
            if (storagePoint == null)
            {
                return HttpNotFound();
            }
            return View(storagePoint);
        }

        // POST: StoragePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoragePoint storagePoint = db.StoragePoints.Find(id);
            db.StoragePoints.Remove(storagePoint);
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

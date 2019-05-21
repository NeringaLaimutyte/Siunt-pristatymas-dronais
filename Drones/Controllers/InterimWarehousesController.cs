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
    public class InterimWarehousesController : Controller
    {
        private DronesContext db = new DronesContext();

        // GET: InterimWarehouses
        public ActionResult Index()
        {
            return View(db.InterimWarehouses.ToList());
        }

        // GET: InterimWarehouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterimWarehouse interimWarehouse = db.InterimWarehouses.Find(id);
            if (interimWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(interimWarehouse);
        }

        // GET: InterimWarehouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterimWarehouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address")] InterimWarehouse interimWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.InterimWarehouses.Add(interimWarehouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interimWarehouse);
        }

        // GET: InterimWarehouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterimWarehouse interimWarehouse = db.InterimWarehouses.Find(id);
            if (interimWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(interimWarehouse);
        }

        // POST: InterimWarehouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address")] InterimWarehouse interimWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interimWarehouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interimWarehouse);
        }

        // GET: InterimWarehouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterimWarehouse interimWarehouse = db.InterimWarehouses.Find(id);
            if (interimWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(interimWarehouse);
        }

        // POST: InterimWarehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterimWarehouse interimWarehouse = db.InterimWarehouses.Find(id);
            db.InterimWarehouses.Remove(interimWarehouse);
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

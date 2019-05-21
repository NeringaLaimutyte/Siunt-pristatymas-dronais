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
    public class PollTimesController : Controller
    {
        private DronesContext db = new DronesContext();

        // GET: PollTimes
        public ActionResult Index()
        {
            return View(db.PollTimes.ToList());
        }

        // GET: PollTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PollTime pollTime = db.PollTimes.Find(id);
            if (pollTime == null)
            {
                return HttpNotFound();
            }
            return View(pollTime);
        }

        // GET: PollTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PollTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IntervalDuration")] PollTime pollTime)
        {
            if (ModelState.IsValid)
            {
                db.PollTimes.Add(pollTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pollTime);
        }

        // GET: PollTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PollTime pollTime = db.PollTimes.Find(id);
            if (pollTime == null)
            {
                return HttpNotFound();
            }
            return View(pollTime);
        }

        // POST: PollTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IntervalDuration")] PollTime pollTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pollTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pollTime);
        }

        // GET: PollTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PollTime pollTime = db.PollTimes.Find(id);
            if (pollTime == null)
            {
                return HttpNotFound();
            }
            return View(pollTime);
        }

        // POST: PollTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PollTime pollTime = db.PollTimes.Find(id);
            db.PollTimes.Remove(pollTime);
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

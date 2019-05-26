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
    public class DronesController : Controller
    {
        private DronesContext db = new DronesContext();

        public ActionResult Main()
        {
            return View();
        }
        // GET: Drones
        public ActionResult Index()
        {
            return View(db.Drones.ToList());
        }

        // POST: Drones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Model")] Drone drone)
        {
            PollController pc = new PollController();
            if (ModelState.IsValid)
            {
                pc.StartPoll();
                ViewBag.Message = "Poll started";
            }
            return View(db.Drones.ToList());
        }


        // GET: Drones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drone drone = db.Drones.Find(id);
            if (drone == null)
            {
                return HttpNotFound();
            }
            return View(drone);
        }

        // GET: Drones/Create
        public ActionResult Create()
        {
            return View();
        }
         // GET: Drones/DeleteById
        public ActionResult DeleteById()
        {
            return View();
        }


      


        // POST: Drones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model")] Drone drone)
        {
            if (ModelState.IsValid)
            {
                drone.BatteryCharging = 0;
                drone.Status = DroneStatus.off;
                db.Drones.Add(drone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drone);
        }

        // GET: Drones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drone drone = db.Drones.Find(id);
            if (drone == null)
            {
                return HttpNotFound();
            }
            return View(drone);
        }

        // POST: Drones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model")] Drone drone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drone);
        }

        // GET: Drones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drone drone = db.Drones.Find(id);
            if (drone == null)
            {
                return HttpNotFound();
            }
            return View(drone);
        }

        // POST: Drones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drone drone = db.Drones.Find(id);
            db.Drones.Remove(drone);
            var polls = db.Polls.ToList();
            bool droneHasPoll = false;
            for (int i = 0; i < polls.Count; i++)
            {
                if (polls[i].Drone_Id==drone.Id)
                {
                    droneHasPoll = true;
                }
            }
            if (!droneHasPoll)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Delete = "Drone has poll";
                return View(drone);
            }
        }
        public ActionResult SendToWarehouse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drone drone = db.Drones.Find(id);
            if (drone == null)
            {
                return HttpNotFound();
            }
            return View(drone);
        }
        // POST: Drones/SendToWarehouse/5 
        [HttpPost, ActionName("SendToWarehouse")]
        [ValidateAntiForgeryToken]
        public ActionResult SendToWarehouseConfirmed(int id)
        {
            Drone drone = db.Drones.Find(id);
            drone.UpdateStatus(DroneStatus.comingBackToWarehouse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SendToCharge(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drone drone = db.Drones.Find(id);
            if (drone == null)
            {
                return HttpNotFound();
            }
            return View(drone);
        }
        // POST: Drones/SendToWarehouse/5 
        [HttpPost, ActionName("SendToCharge")]
        [ValidateAntiForgeryToken]
        public ActionResult SendToChargeConfirmed(int id)
        {
            Drone drone = db.Drones.Find(id);
            drone.UpdateStatus(DroneStatus.charging);
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

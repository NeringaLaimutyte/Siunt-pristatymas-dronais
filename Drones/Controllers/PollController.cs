using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drones;
using Drones.Models;

namespace Drones.Controllers
{
    public class PollController : Controller
    {
        List<Drone> SMSList = new List<Drone>(); 
        private DronesContext db = new DronesContext();
        // GET: Poll
        public ActionResult Index()
        {
            return View(db.Polls.ToList());
        }
        public void StartPoll()
        {
            DataGenerator dg = new DataGenerator();
            Supervisor user = dg.SupervisorGenerator(1);
            List<Drone> drones = db.Drones.ToList();
            foreach (var drone in drones)
            {
                Poll state = drone.GetState(drone.Id);
                Update(drone, state);
                Insert(drone, state);
                if(user.CheckUserRole() == "Supervisor")
                {
                    RefreshState(drone.Id);
                }

                AppendToSMSList(drone, state);
            }
            if (SMSList.Count>0)
            {
                //sendSms();
            }

            if (user.CheckUserRole() == "Supervisor")
            {
                ViewBag.Message = "Poll completed";
            }
            RedirectToAction("Index");
        }
        public void Update(Drone drone, Poll state)
        {
            drone.Update(state);
        }
        public void Insert(Drone drone, Poll state)
        {
            Poll dbPoll = db.Polls.FirstOrDefault(p => p.Drone_Id == drone.Id);
            if(dbPoll == null)
            {
                db.Polls.Add(state);
            }
            else
            {
                dbPoll = state;
            }
            db.SaveChanges();
        }
        public void AppendToSMSList(Drone drone, Poll state)
        {
            if (state.FailureCode != "")
            {
                SMSList.Add(drone);
            }
        }
        public void RefreshState(int id)
        {
            Drone drone = db.Drones.FirstOrDefault(p => p.Id == id);
            Poll dbPoll = db.Polls.FirstOrDefault(p => p.Drone_Id == drone.Id);
            Poll poll = drone.RefreshState(drone);
            dbPoll.FailureCode = poll.FailureCode;
            dbPoll.Location = poll.Location;
            dbPoll.BatteryBalance = poll.BatteryBalance;
            dbPoll.PollTime = poll.PollTime;
            dbPoll.ProphylaxisTime = poll.ProphylaxisTime;
            dbPoll.Status = poll.Status;
            db.SaveChanges();
        }
        // GET: PollTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll pollTime = db.Polls.Find(id);
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
            Poll pollTime = db.Polls.Find(id);
            db.Polls.Remove(pollTime);
            db.SaveChanges();
            return RedirectToAction("Index");
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
        public ActionResult Create([Bind(Include = "Id,IntervalDuration")] Poll pollTime)
        {
            if (ModelState.IsValid)
            {
                StartPoll();
                return RedirectToAction("../Drones/Index");
            }

            return View(pollTime);
        }
    }
}
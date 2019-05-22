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
        StateDetails sd = new StateDetails();
        List<Drone> SMSList = new List<Drone>(); 
        private DronesContext db = new DronesContext();
        // GET: Poll
        public ActionResult Index()
        {
            return View();
        }
        public void StartPoll()
        {
            List<Drone> drones = db.Drones.ToList();
            foreach (var drone in drones)
            {
                StateDetails state = drone.GetState(drone);
                Update(drone, state);
                Insert(state);
                //if (supervisorStartedPoll)
                //{
                //    RefreshState();
                //}
                AppendToSMSList(drone, state);
            }
            if (SMSList.Count>0)
            {
                //SendSMS();
            }
            //if (supervisorStartedPoll)
            //{
            //    Poll completed
            //}
        }
        public void Update(Drone drone, StateDetails state)
        {
            drone.Update(state);
        }
        public void Insert(StateDetails state)
        {
            db.StateDetails.Add(state);
        }
        public void AppendToSMSList(Drone drone, StateDetails state)
        {
            if (state.FailureCode != "")
            {
                SMSList.Add(drone);
            }
        }
        public void RefreshState()
        {
            //refresh
        }
    }
}
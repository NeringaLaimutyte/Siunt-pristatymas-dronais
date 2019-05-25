using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class Drone
    {
        public int Id { get; set; }
        public String Model { get; set; }
        public Boolean NeedToServe { get; set; }
        public DroneStatus Status { get; set; }
        public Supervisor Supervisor { get; set; }
        public Shipment[] Shipment { get; set; }
        public int BatteryCharging { get; set; }
        public InterimWarehouse InterimWarehouse { get; set; }
        public Poll Poll { get; set; }
        public void Update(Poll poll)
        {
            BatteryCharging = poll.BatteryBalance;
            Status = poll.Status;
            //StateDetails.Add(stateDetails);
        }
        DataGenerator dg = new DataGenerator();
        public Poll GetState(int id)
        {
            return dg.StateDetailsGenerator(id);
        }

        public Poll RefreshState(Drone drone)
        {
            return dg.StateDetailsRefresh(drone);
        }
        public void ChangeDroneState()
        {

        }
        public void AssignDestination()
        {

        }
    }
}
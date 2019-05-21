using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class Drone
    {
        public int Id { get; set; }
        public String Number { get; set; }
        public int Model { get; set; }
        public Boolean NeedToServe { get; set; }
        public virtual ICollection<DroneStatus> Status { get; set; }
        public Supervisor Supervisor { get; set; }
        public Shipment[] Shipment { get; set; }
        public int BatteryCharging { get; set; }
        public InterimWarehouse InterimWarehouse { get; set; }
        public StateDetails[] StateDetails { get; set; }

        public void Select()
        {

        }
        public void Update()
        {

        }
        public void Add()
        {

        }
        public void Delete()
        {

        }
        public void Edit()
        {

        }
        public void GetState()
        {

        }
        public void ChangeDroneState()
        {

        }
        public void AssignDestination()
        {

        }
    }
}
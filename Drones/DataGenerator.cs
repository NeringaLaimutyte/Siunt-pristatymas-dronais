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

namespace Drones
{
    public class DataGenerator
    {
        public Poll StateDetailsGenerator(int id)
        {
            Poll sd = new Poll(id, 20, "123", "Kaunas", DateTime.Now, DroneStatus.waitingForTaskInWarehouse, id);
            return sd;
        }

        public Poll StateDetailsRefresh(Drone drone)
        {
            Random rnd = new Random();
            int status = rnd.Next(0, 5);
            switch (status)
            {
                case 0: drone.Status = DroneStatus.broken;
                    break;
                case 1: drone.Status = DroneStatus.charging;
                    break;
                case 2: drone.Status = DroneStatus.comingBackToWarehouse;
                    break;
                case 3: drone.Status = DroneStatus.deliveringShipment;
                    break;
                case 4: drone.Status = DroneStatus.off;
                    break;
                case 5: drone.Status = DroneStatus.waitingForTaskInWarehouse;
                    break;
            }
            Poll sd = new Poll(drone.Id, drone.BatteryCharging, "123", "Kaunas", DateTime.Now, drone.Status, drone.Id);
            return sd;
        }
    }
}
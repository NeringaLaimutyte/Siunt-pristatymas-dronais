using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class Supervisor : User
    {
        public String TelephoneNumber { get; set; }
        public Drone[] AssaignedDrone { get; set; }
        public Notification[] DroneList { get; set; }
        public void Appoint()
        {

        }
        public void Add()
        {

        }
        public void Delete()
        {

        }
        public void Select()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class InterimWarehouse
    {
        public int Id { get; set; }
        public String Address { get; set; }
        public Shipment[] Shipment { get; set; }
        public Drone[] Drone { get; set; }
        public void MarkAsSelected()
        {

        }
        public void GetList()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class StoragePoint
    {
        public int Id { get; set; }
        public String Address { get; set; }
        public Shipment[] Shipment { get; set; }
        public void MarkAsSelected()
        {

        }
        public void Select()
        {

        }
    }
}
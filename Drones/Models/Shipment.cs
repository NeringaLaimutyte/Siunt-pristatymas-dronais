using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public String Code { get; set; }
        public int Weight { get; set; }
        public virtual ICollection<ShipmentStatus> State { get; set; }
        public InterimWarehouse TakeAdress { get; set; }
        public StoragePoint DeliveryAdress { get; set; }
        public Drone Drone { get; set; }
        public void Select()
        {

        }
        public void Delete()
        {

        }
        public void Add()
        {

        }
        public void GetList()
        {

        }
        public void GetPackageDestination()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public DateTime DispatchTime { get; set; }
        public bool IsSent = false;
        public Supervisor Reciever { get; set; }
    }
}
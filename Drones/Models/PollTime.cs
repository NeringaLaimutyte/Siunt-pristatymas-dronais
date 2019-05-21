using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class PollTime
    {
        public int Id { get; set; }
        public int IntervalDuration { get; set; }
        public Manager Manager { get; set; }
        public void Submit()
        {

        }
    }
}
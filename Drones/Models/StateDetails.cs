using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class StateDetails
    {
        public int Id { get; set; }
        public Drone PolledMachine { get; set; }
        public int BatteryBalance { get; set; }
        public String FailureCode { get; set; }
        public String Location { get; set; }
        public DateTime PollTime { get; set; }
        public DateTime ProphylaxisTime { get; set; }
        public void GetState()
        {

        }
    }
}
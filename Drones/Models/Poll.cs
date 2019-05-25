using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class Poll
    {
        public Poll() { }
        public Poll(int id, int batteryBalance, string failureCode, string location, DateTime pollTime, DroneStatus status,  int drone_Id)
        {
            Id = id;
            BatteryBalance = batteryBalance;
            FailureCode = failureCode;
            Location = location;
            PollTime = pollTime;
            Status = status;
            Drone_Id = drone_Id;
        }
        public int Id { get; set; }
        public int Drone_Id { get; set; }
        public int BatteryBalance { get; set; }
        public String FailureCode { get; set; }
        public String Location { get; set; }
        public DateTime PollTime { get; set; }
        public DroneStatus Status { get; set; }
        public DateTime ProphylaxisTime { get; set; }
    }
}
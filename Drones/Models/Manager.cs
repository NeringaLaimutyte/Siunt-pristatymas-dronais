using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public class Manager : User
    {
        public PollTime[] PollTime { get; set; }
    }
}
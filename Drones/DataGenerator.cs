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
        public StateDetails StateDetailsGenerator(Drone drone)
        {
            StateDetails sd = new StateDetails(0, 20, "123", "Kaunas", DateTime.Now, drone);
            return sd;
        }
    }
}
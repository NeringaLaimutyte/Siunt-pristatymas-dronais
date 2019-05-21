using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drones.Models
{
    public enum DroneStatus
    {
        broken,
        off,
        charging,
        waitingForTaskInWarehouse,
        deliveringShipment,
        comingBackToWarehouse,
    }
}
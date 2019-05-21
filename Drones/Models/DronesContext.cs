using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySql.Data.Entity;
using Drones.Models;

namespace Drones.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DronesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DronesContext() : base("WebAppCon")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<PollTime> PollTimes { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<StateDetails> StateDetails { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<StoragePoint> StoragePoints { get; set; }
        public DbSet<InterimWarehouse> InterimWarehouses { get; set; }

    }
}

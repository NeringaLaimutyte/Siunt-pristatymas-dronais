namespace Drones.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    internal sealed class Configuration : DbMigrationsConfiguration<Drones.Models.DronesContext>
    {
        public Configuration()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Drones.Models.DronesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

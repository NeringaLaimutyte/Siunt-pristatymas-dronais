namespace Drones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        TelephoneNumber = c.String(unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(unicode: false),
                        Model = c.Int(nullable: false),
                        NeedToServe = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        BatteryCharging = c.Int(nullable: false),
                        InterimWarehouse_Id = c.Int(),
                        Poll_Id = c.Int(),
                        Supervisor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterimWarehouses", t => t.InterimWarehouse_Id)
                .ForeignKey("dbo.Polls", t => t.Poll_Id)
                .ForeignKey("dbo.Users", t => t.Supervisor_Id)
                .Index(t => t.InterimWarehouse_Id)
                .Index(t => t.Poll_Id)
                .Index(t => t.Supervisor_Id);
            
            CreateTable(
                "dbo.InterimWarehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Polls",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Drone_Id = c.Int(nullable: false),
                    BatteryBalance = c.Int(nullable: false),
                    FailureCode = c.String(unicode: false),
                    Location = c.String(unicode: false),
                    PollTime = c.DateTime(nullable: false, precision: 0),
                    Status = c.Int(nullable: false),
                    ProphylaxisTime = c.DateTime(nullable: false, precision: 0),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drones", t => t.Drone_Id)
                .Index(t => t.Drone_Id);


            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(unicode: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(unicode: false),
                        DispatchTime = c.DateTime(nullable: false, precision: 0),
                        Reciever_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Reciever_Id)
                .Index(t => t.Reciever_Id);
            
            CreateTable(
                "dbo.PollTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntervalDuration = c.Int(nullable: false),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Manager_Id)
                .Index(t => t.Manager_Id);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(unicode: false),
                        Weight = c.Int(nullable: false),
                        DeliveryAdress_Id = c.Int(),
                        Drone_Id = c.Int(),
                        TakeAdress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StoragePoints", t => t.DeliveryAdress_Id)
                .ForeignKey("dbo.Drones", t => t.Drone_Id)
                .ForeignKey("dbo.InterimWarehouses", t => t.TakeAdress_Id)
                .Index(t => t.DeliveryAdress_Id)
                .Index(t => t.Drone_Id)
                .Index(t => t.TakeAdress_Id);
            
            CreateTable(
                "dbo.StoragePoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipments", "TakeAdress_Id", "dbo.InterimWarehouses");
            DropForeignKey("dbo.Shipments", "Drone_Id", "dbo.Drones");
            DropForeignKey("dbo.Shipments", "DeliveryAdress_Id", "dbo.StoragePoints");
            DropForeignKey("dbo.PollTimes", "Manager_Id", "dbo.Users");
            DropForeignKey("dbo.Notifications", "Reciever_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Customer_Id", "dbo.Users");
            DropForeignKey("dbo.Drones", "Supervisor_Id", "dbo.Users");
            DropForeignKey("dbo.Drones", "Poll_Id", "dbo.Polls");
            DropForeignKey("dbo.Drones", "InterimWarehouse_Id", "dbo.InterimWarehouses");
            DropIndex("dbo.Shipments", new[] { "TakeAdress_Id" });
            DropIndex("dbo.Shipments", new[] { "Drone_Id" });
            DropIndex("dbo.Shipments", new[] { "DeliveryAdress_Id" });
            DropIndex("dbo.PollTimes", new[] { "Manager_Id" });
            DropIndex("dbo.Notifications", new[] { "Reciever_Id" });
            DropIndex("dbo.Messages", new[] { "Customer_Id" });
            DropIndex("dbo.Drones", new[] { "Supervisor_Id" });
            DropIndex("dbo.Drones", new[] { "Poll_Id" });
            DropIndex("dbo.Drones", new[] { "InterimWarehouse_Id" });
            DropTable("dbo.StoragePoints");
            DropTable("dbo.Shipments");
            DropTable("dbo.PollTimes");
            DropTable("dbo.Notifications");
            DropTable("dbo.Messages");
            DropTable("dbo.Polls");
            DropTable("dbo.InterimWarehouses");
            DropTable("dbo.Drones");
            DropTable("dbo.Users");
        }
    }
}

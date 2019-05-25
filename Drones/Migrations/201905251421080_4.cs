namespace Drones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drones", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drones", "Number", c => c.Int(nullable: false));
        }
    }
}

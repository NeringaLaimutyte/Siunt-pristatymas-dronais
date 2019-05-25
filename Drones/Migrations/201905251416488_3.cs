namespace Drones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drones", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Drones", "Model", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drones", "Model", c => c.Int(nullable: false));
            AlterColumn("dbo.Drones", "Number", c => c.String(unicode: false));
        }
    }
}

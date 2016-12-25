namespace ClinicsRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleItems", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleItems", "Price");
        }
    }
}

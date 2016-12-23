namespace ClinicsRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ScheduleItems", name: "ClientCard_Id", newName: "Client_Id");
            RenameIndex(table: "dbo.ScheduleItems", name: "IX_ClientCard_Id", newName: "IX_Client_Id");
            DropColumn("dbo.ScheduleItems", "ClientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScheduleItems", "ClientId", c => c.Guid(nullable: false));
            RenameIndex(table: "dbo.ScheduleItems", name: "IX_Client_Id", newName: "IX_ClientCard_Id");
            RenameColumn(table: "dbo.ScheduleItems", name: "Client_Id", newName: "ClientCard_Id");
        }
    }
}

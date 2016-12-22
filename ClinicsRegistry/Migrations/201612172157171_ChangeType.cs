namespace ClinicsRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeType : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ScheduleItems");
            DropTable("dbo.ClientCards");
            CreateTable(
                "dbo.ClientCards",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        IsEmployee = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            CreateTable(
                "dbo.ScheduleItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        ClientCard_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientCards", t => t.ClientCard_Id)
                .Index(t => t.ClientCard_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleItems", "ClientCard_Id", "dbo.ClientCards");
            DropIndex("dbo.ScheduleItems", new[] { "ClientCard_Id" });
            DropTable("dbo.ScheduleItems");
            DropTable("dbo.ClientCards");
        }
    }
}

namespace ClinicsRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SymptomDiseases",
                c => new
                    {
                        Symptom_Id = c.Guid(nullable: false),
                        Disease_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Symptom_Id, t.Disease_Id })
                .ForeignKey("dbo.Symptoms", t => t.Symptom_Id, cascadeDelete: true)
                .ForeignKey("dbo.Diseases", t => t.Disease_Id, cascadeDelete: true)
                .Index(t => t.Symptom_Id)
                .Index(t => t.Disease_Id);
            
            AddColumn("dbo.ScheduleItems", "Diagnosis_Id", c => c.Guid());
            CreateIndex("dbo.ScheduleItems", "Diagnosis_Id");
            AddForeignKey("dbo.ScheduleItems", "Diagnosis_Id", "dbo.Diseases", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleItems", "Diagnosis_Id", "dbo.Diseases");
            DropForeignKey("dbo.SymptomDiseases", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.SymptomDiseases", "Symptom_Id", "dbo.Symptoms");
            DropIndex("dbo.SymptomDiseases", new[] { "Disease_Id" });
            DropIndex("dbo.SymptomDiseases", new[] { "Symptom_Id" });
            DropIndex("dbo.ScheduleItems", new[] { "Diagnosis_Id" });
            DropColumn("dbo.ScheduleItems", "Diagnosis_Id");
            DropTable("dbo.SymptomDiseases");
            DropTable("dbo.Symptoms");
            DropTable("dbo.Diseases");
        }
    }
}

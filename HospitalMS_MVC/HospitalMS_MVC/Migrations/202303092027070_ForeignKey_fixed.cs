namespace HospitalMS_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey_fixed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IPDAdmits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        NightCount = c.Int(nullable: false),
                        CabinId = c.Int(),
                        WardId = c.Int(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cabins", t => t.CabinId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Wards", t => t.WardId)
                .Index(t => t.PatientId)
                .Index(t => t.CabinId)
                .Index(t => t.WardId);
            
            AddColumn("dbo.DiagLists", "Cost", c => c.Single(nullable: false));
            DropColumn("dbo.DiagLists", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiagLists", "Price", c => c.Single(nullable: false));
            DropForeignKey("dbo.IPDAdmits", "WardId", "dbo.Wards");
            DropForeignKey("dbo.IPDAdmits", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.IPDAdmits", "CabinId", "dbo.Cabins");
            DropIndex("dbo.IPDAdmits", new[] { "WardId" });
            DropIndex("dbo.IPDAdmits", new[] { "CabinId" });
            DropIndex("dbo.IPDAdmits", new[] { "PatientId" });
            DropColumn("dbo.DiagLists", "Cost");
            DropTable("dbo.IPDAdmits");
        }
    }
}

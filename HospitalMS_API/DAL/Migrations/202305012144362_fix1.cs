namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IPDAdmits",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IPDName = c.String(),
                        PatientId = c.Int(nullable: false),
                        NightCount = c.Int(nullable: false),
                        CabinId = c.Int(),
                        WardId = c.Int(),
                        Status = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cabins", t => t.CabinId)
                .ForeignKey("dbo.IPDBills", t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Wards", t => t.WardId)
                .Index(t => t.Id)
                .Index(t => t.PatientId)
                .Index(t => t.CabinId)
                .Index(t => t.WardId);
            
            CreateTable(
                "dbo.IPDBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        TotalAmount = c.Int(nullable: false),
                        PaidAmount = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IPDAdmits", "WardId", "dbo.Wards");
            DropForeignKey("dbo.IPDAdmits", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.IPDAdmits", "Id", "dbo.IPDBills");
            DropForeignKey("dbo.IPDBills", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.IPDAdmits", "CabinId", "dbo.Cabins");
            DropIndex("dbo.IPDBills", new[] { "PatientId" });
            DropIndex("dbo.IPDAdmits", new[] { "WardId" });
            DropIndex("dbo.IPDAdmits", new[] { "CabinId" });
            DropIndex("dbo.IPDAdmits", new[] { "PatientId" });
            DropIndex("dbo.IPDAdmits", new[] { "Id" });
            DropTable("dbo.IPDBills");
            DropTable("dbo.IPDAdmits");
        }
    }
}

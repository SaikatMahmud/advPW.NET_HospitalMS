namespace HospitalMS_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3_new_table : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.IPDAdmits");
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        Status = c.String(),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.IPDBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        IPDAdmitId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.LeaveApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffId = c.Int(nullable: false),
                        Details = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId);
            
            AddColumn("dbo.Patients", "Username", c => c.String());
            AddColumn("dbo.Patients", "Password", c => c.String());
            AddColumn("dbo.Patients", "Type", c => c.String());
            AddColumn("dbo.Staffs", "Username", c => c.String());
            AddColumn("dbo.Staffs", "Password", c => c.String());
            AddColumn("dbo.Staffs", "Type", c => c.String());
            AlterColumn("dbo.IPDAdmits", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.IPDAdmits", "Id");
            CreateIndex("dbo.OPDBills", "PatientId");
            CreateIndex("dbo.IPDAdmits", "Id");
            AddForeignKey("dbo.IPDAdmits", "Id", "dbo.IPDBills", "Id");
            AddForeignKey("dbo.OPDBills", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveApplications", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.OPDBills", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.IPDAdmits", "Id", "dbo.IPDBills");
            DropForeignKey("dbo.IPDBills", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Complaints", "PatientId", "dbo.Patients");
            DropIndex("dbo.LeaveApplications", new[] { "StaffId" });
            DropIndex("dbo.IPDBills", new[] { "PatientId" });
            DropIndex("dbo.IPDAdmits", new[] { "Id" });
            DropIndex("dbo.Complaints", new[] { "PatientId" });
            DropIndex("dbo.OPDBills", new[] { "PatientId" });
            DropPrimaryKey("dbo.IPDAdmits");
            AlterColumn("dbo.IPDAdmits", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Staffs", "Type");
            DropColumn("dbo.Staffs", "Password");
            DropColumn("dbo.Staffs", "Username");
            DropColumn("dbo.Patients", "Type");
            DropColumn("dbo.Patients", "Password");
            DropColumn("dbo.Patients", "Username");
            DropTable("dbo.LeaveApplications");
            DropTable("dbo.IPDBills");
            DropTable("dbo.Complaints");
            DropTable("dbo.Admins");
            AddPrimaryKey("dbo.IPDAdmits", "Id");
        }
    }
}

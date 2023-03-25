namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tier_db_create : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        ScheduleTime = c.DateTime(nullable: false),
                        BookTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        AboutDoctor = c.String(maxLength: 200),
                        Designation = c.String(maxLength: 20),
                        Gender = c.String(),
                        Mobile = c.String(maxLength: 20),
                        Email = c.String(),
                        Room = c.String(),
                        StayFrom = c.DateTime(nullable: false),
                        StayTill = c.DateTime(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        DeptId = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        Fee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiagLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Cost = c.Single(nullable: false),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.PerformDiags",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DiagId = c.Int(nullable: false),
                        StoragePath = c.String(),
                        Status = c.String(nullable: false, maxLength: 10),
                        DeliverDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiagLists", t => t.DiagId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.OPDBillDetails", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.PatientId)
                .Index(t => t.DiagId);
            
            CreateTable(
                "dbo.OPDBillDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OPDBillId = c.Int(nullable: false),
                        DoctorId = c.Int(),
                        Amount = c.Single(nullable: false),
                        Discount = c.Int(nullable: false),
                        BillType = c.String(),
                        PerformDiagId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.OPDBills", t => t.OPDBillId, cascadeDelete: true)
                .Index(t => t.OPDBillId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.OPDBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillAmount = c.Single(nullable: false),
                        PaidAmount = c.Single(nullable: false),
                        PatientId = c.Int(nullable: false),
                        BillDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 15),
                        BloodGroup = c.String(nullable: false, maxLength: 5),
                        Mobile = c.String(nullable: false, maxLength: 20),
                        Email = c.String(),
                        Address = c.String(),
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
                "dbo.IPDAdmits",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                "dbo.Cabins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CabinNo = c.Int(nullable: false),
                        PatientBed = c.Int(nullable: false),
                        GuestBed = c.Int(nullable: false),
                        Rent = c.Int(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BedCout = c.Int(nullable: false),
                        Rent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        Details = c.String(),
                        DoctorId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Designation = c.String(),
                        Gender = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Type = c.String(),
                        DeptId = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveApplications", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Doctors", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.PerformDiags", "Id", "dbo.OPDBillDetails");
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PerformDiags", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.OPDBills", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.IPDAdmits", "WardId", "dbo.Wards");
            DropForeignKey("dbo.IPDAdmits", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.IPDAdmits", "Id", "dbo.IPDBills");
            DropForeignKey("dbo.IPDBills", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.IPDAdmits", "CabinId", "dbo.Cabins");
            DropForeignKey("dbo.Complaints", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.OPDBillDetails", "OPDBillId", "dbo.OPDBills");
            DropForeignKey("dbo.OPDBillDetails", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PerformDiags", "DiagId", "dbo.DiagLists");
            DropForeignKey("dbo.DiagLists", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.LeaveApplications", new[] { "StaffId" });
            DropIndex("dbo.Staffs", new[] { "DeptId" });
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropIndex("dbo.IPDBills", new[] { "PatientId" });
            DropIndex("dbo.IPDAdmits", new[] { "WardId" });
            DropIndex("dbo.IPDAdmits", new[] { "CabinId" });
            DropIndex("dbo.IPDAdmits", new[] { "PatientId" });
            DropIndex("dbo.IPDAdmits", new[] { "Id" });
            DropIndex("dbo.Complaints", new[] { "PatientId" });
            DropIndex("dbo.OPDBills", new[] { "PatientId" });
            DropIndex("dbo.OPDBillDetails", new[] { "DoctorId" });
            DropIndex("dbo.OPDBillDetails", new[] { "OPDBillId" });
            DropIndex("dbo.PerformDiags", new[] { "DiagId" });
            DropIndex("dbo.PerformDiags", new[] { "PatientId" });
            DropIndex("dbo.PerformDiags", new[] { "Id" });
            DropIndex("dbo.DiagLists", new[] { "DeptId" });
            DropIndex("dbo.Doctors", new[] { "DeptId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.LeaveApplications");
            DropTable("dbo.Staffs");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Wards");
            DropTable("dbo.IPDBills");
            DropTable("dbo.Cabins");
            DropTable("dbo.IPDAdmits");
            DropTable("dbo.Complaints");
            DropTable("dbo.Patients");
            DropTable("dbo.OPDBills");
            DropTable("dbo.OPDBillDetails");
            DropTable("dbo.PerformDiags");
            DropTable("dbo.DiagLists");
            DropTable("dbo.Departments");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
            DropTable("dbo.Admins");
        }
    }
}

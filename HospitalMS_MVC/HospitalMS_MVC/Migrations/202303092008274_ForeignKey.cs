namespace HospitalMS_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiagLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PerformDiags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DiagId = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        StoragePath = c.String(),
                        Status = c.String(),
                        DeliverDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiagLists", t => t.DiagId, cascadeDelete: true)
                .ForeignKey("dbo.OPDBills", t => t.BillId, cascadeDelete: true)
                .Index(t => t.BillId)
                .Index(t => t.DiagId);
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cabins", "Rent", c => c.Int(nullable: false));
            AddColumn("dbo.Wards", "Rent", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "DoctorId");
            CreateIndex("dbo.Appointments", "PatientId");
            CreateIndex("dbo.Doctors", "DeptId");
            CreateIndex("dbo.Staffs", "DeptId");
            CreateIndex("dbo.Prescriptions", "PatientId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Doctors", "DeptId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Staffs", "DeptId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            DropTable("dbo.AvailableDiags");
            DropTable("dbo.Bills");
            DropTable("dbo.DiagRecords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DiagRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        OrderedTestId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        BillDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AvailableDiags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.PerformDiags", "BillId", "dbo.OPDBills");
            DropForeignKey("dbo.PerformDiags", "DiagId", "dbo.DiagLists");
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Staffs", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Doctors", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.PerformDiags", new[] { "DiagId" });
            DropIndex("dbo.PerformDiags", new[] { "BillId" });
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropIndex("dbo.Staffs", new[] { "DeptId" });
            DropIndex("dbo.Doctors", new[] { "DeptId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropColumn("dbo.Wards", "Rent");
            DropColumn("dbo.Cabins", "Rent");
            DropTable("dbo.OPDBills");
            DropTable("dbo.PerformDiags");
            DropTable("dbo.DiagLists");
        }
    }
}

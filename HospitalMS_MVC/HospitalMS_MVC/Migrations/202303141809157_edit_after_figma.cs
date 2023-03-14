namespace HospitalMS_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_after_figma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PerformDiags", "BillId", "dbo.OPDBills");
            DropIndex("dbo.PerformDiags", new[] { "BillId" });
            DropPrimaryKey("dbo.PerformDiags");
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
            
            AddColumn("dbo.Doctors", "Room", c => c.String());
            AddColumn("dbo.Doctors", "StayFrom", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "StayTill", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "Salary", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "Fee", c => c.Int(nullable: false));
            AddColumn("dbo.Staffs", "Salary", c => c.Int(nullable: false));
            AlterColumn("dbo.PerformDiags", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PerformDiags", "Id");
            CreateIndex("dbo.PerformDiags", "Id");
            CreateIndex("dbo.PerformDiags", "PatientId");
            AddForeignKey("dbo.PerformDiags", "Id", "dbo.OPDBillDetails", "Id");
            AddForeignKey("dbo.PerformDiags", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            DropColumn("dbo.PerformDiags", "BillId");
            DropColumn("dbo.PerformDiags", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PerformDiags", "Amount", c => c.Single(nullable: false));
            AddColumn("dbo.PerformDiags", "BillId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PerformDiags", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PerformDiags", "Id", "dbo.OPDBillDetails");
            DropForeignKey("dbo.OPDBillDetails", "OPDBillId", "dbo.OPDBills");
            DropForeignKey("dbo.OPDBillDetails", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.OPDBillDetails", new[] { "DoctorId" });
            DropIndex("dbo.OPDBillDetails", new[] { "OPDBillId" });
            DropIndex("dbo.PerformDiags", new[] { "PatientId" });
            DropIndex("dbo.PerformDiags", new[] { "Id" });
            DropPrimaryKey("dbo.PerformDiags");
            AlterColumn("dbo.PerformDiags", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Staffs", "Salary");
            DropColumn("dbo.Doctors", "Fee");
            DropColumn("dbo.Doctors", "Salary");
            DropColumn("dbo.Doctors", "StayTill");
            DropColumn("dbo.Doctors", "StayFrom");
            DropColumn("dbo.Doctors", "Room");
            DropTable("dbo.OPDBillDetails");
            AddPrimaryKey("dbo.PerformDiags", "Id");
            CreateIndex("dbo.PerformDiags", "BillId");
            AddForeignKey("dbo.PerformDiags", "BillId", "dbo.OPDBills", "Id", cascadeDelete: true);
        }
    }
}

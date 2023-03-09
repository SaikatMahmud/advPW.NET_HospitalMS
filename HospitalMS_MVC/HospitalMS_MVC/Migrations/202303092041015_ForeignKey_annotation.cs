namespace HospitalMS_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey_annotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Doctors", "AboutDoctor", c => c.String(maxLength: 200));
            AlterColumn("dbo.Doctors", "Designation", c => c.String(maxLength: 20));
            AlterColumn("dbo.Doctors", "Mobile", c => c.String(maxLength: 20));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.DiagLists", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.PerformDiags", "Status", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Patients", "Gender", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Patients", "BloodGroup", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Patients", "Mobile", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.IPDAdmits", "Status", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IPDAdmits", "Status", c => c.String());
            AlterColumn("dbo.Patients", "Mobile", c => c.String());
            AlterColumn("dbo.Patients", "BloodGroup", c => c.String());
            AlterColumn("dbo.Patients", "Gender", c => c.String());
            AlterColumn("dbo.Patients", "Name", c => c.String());
            AlterColumn("dbo.PerformDiags", "Status", c => c.String());
            AlterColumn("dbo.DiagLists", "Name", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
            AlterColumn("dbo.Doctors", "Mobile", c => c.String());
            AlterColumn("dbo.Doctors", "Designation", c => c.String());
            AlterColumn("dbo.Doctors", "AboutDoctor", c => c.String());
            AlterColumn("dbo.Doctors", "Name", c => c.String());
        }
    }
}

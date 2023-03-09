namespace HospitalMS_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableColumnAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AllTestLists", newName: "DiagRecords");
            CreateTable(
                "dbo.AvailableDiags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "ScheduleTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "BookTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bills", "Amount", c => c.Single(nullable: false));
            AddColumn("dbo.Bills", "OrderedTestId", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "BillDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cabins", "CabinNo", c => c.Int(nullable: false));
            AddColumn("dbo.Cabins", "PatientBed", c => c.Int(nullable: false));
            AddColumn("dbo.Cabins", "GuestBed", c => c.Int(nullable: false));
            AddColumn("dbo.Cabins", "Category", c => c.String());
            AddColumn("dbo.Departments", "Name", c => c.String());
            AddColumn("dbo.Doctors", "Name", c => c.String());
            AddColumn("dbo.Doctors", "AboutDoctor", c => c.String());
            AddColumn("dbo.Doctors", "Designation", c => c.String());
            AddColumn("dbo.Doctors", "Gender", c => c.String());
            AddColumn("dbo.Doctors", "Mobile", c => c.String());
            AddColumn("dbo.Doctors", "Email", c => c.String());
            AddColumn("dbo.Doctors", "JoinDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "DeptId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "Name", c => c.String());
            AddColumn("dbo.Patients", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Patients", "Gender", c => c.String());
            AddColumn("dbo.Patients", "BloodGroup", c => c.String());
            AddColumn("dbo.Patients", "Mobile", c => c.String());
            AddColumn("dbo.Patients", "Email", c => c.String());
            AddColumn("dbo.Patients", "Address", c => c.String());
            AddColumn("dbo.Prescriptions", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.Prescriptions", "Details", c => c.String());
            AddColumn("dbo.Prescriptions", "DoctorId", c => c.Int(nullable: false));
            AddColumn("dbo.Prescriptions", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Staffs", "Name", c => c.String());
            AddColumn("dbo.Staffs", "Designation", c => c.String());
            AddColumn("dbo.Staffs", "Gender", c => c.String());
            AddColumn("dbo.Staffs", "Mobile", c => c.String());
            AddColumn("dbo.Staffs", "Email", c => c.String());
            AddColumn("dbo.Staffs", "JoinDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Staffs", "DeptId", c => c.Int(nullable: false));
            AddColumn("dbo.Wards", "Name", c => c.String());
            AddColumn("dbo.Wards", "BedCout", c => c.Int(nullable: false));
            DropTable("dbo.TestRecords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Wards", "BedCout");
            DropColumn("dbo.Wards", "Name");
            DropColumn("dbo.Staffs", "DeptId");
            DropColumn("dbo.Staffs", "JoinDate");
            DropColumn("dbo.Staffs", "Email");
            DropColumn("dbo.Staffs", "Mobile");
            DropColumn("dbo.Staffs", "Gender");
            DropColumn("dbo.Staffs", "Designation");
            DropColumn("dbo.Staffs", "Name");
            DropColumn("dbo.Prescriptions", "Date");
            DropColumn("dbo.Prescriptions", "DoctorId");
            DropColumn("dbo.Prescriptions", "Details");
            DropColumn("dbo.Prescriptions", "PatientId");
            DropColumn("dbo.Patients", "Address");
            DropColumn("dbo.Patients", "Email");
            DropColumn("dbo.Patients", "Mobile");
            DropColumn("dbo.Patients", "BloodGroup");
            DropColumn("dbo.Patients", "Gender");
            DropColumn("dbo.Patients", "DOB");
            DropColumn("dbo.Patients", "Name");
            DropColumn("dbo.Doctors", "DeptId");
            DropColumn("dbo.Doctors", "JoinDate");
            DropColumn("dbo.Doctors", "Email");
            DropColumn("dbo.Doctors", "Mobile");
            DropColumn("dbo.Doctors", "Gender");
            DropColumn("dbo.Doctors", "Designation");
            DropColumn("dbo.Doctors", "AboutDoctor");
            DropColumn("dbo.Doctors", "Name");
            DropColumn("dbo.Departments", "Name");
            DropColumn("dbo.Cabins", "Category");
            DropColumn("dbo.Cabins", "GuestBed");
            DropColumn("dbo.Cabins", "PatientBed");
            DropColumn("dbo.Cabins", "CabinNo");
            DropColumn("dbo.Bills", "BillDate");
            DropColumn("dbo.Bills", "PatientId");
            DropColumn("dbo.Bills", "OrderedTestId");
            DropColumn("dbo.Bills", "Amount");
            DropColumn("dbo.Appointments", "BookTime");
            DropColumn("dbo.Appointments", "ScheduleTime");
            DropColumn("dbo.Appointments", "PatientId");
            DropColumn("dbo.Appointments", "DoctorId");
            DropTable("dbo.AvailableDiags");
            RenameTable(name: "dbo.DiagRecords", newName: "AllTestLists");
        }
    }
}

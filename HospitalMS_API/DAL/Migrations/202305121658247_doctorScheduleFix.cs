namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctorScheduleFix : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.DoctorsSchedules", "DoctorId");
            AddForeignKey("dbo.DoctorsSchedules", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorsSchedules", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.DoctorsSchedules", new[] { "DoctorId" });
        }
    }
}

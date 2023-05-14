namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctorSchedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorsSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        SlotTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DoctorsSchedules");
        }
    }
}

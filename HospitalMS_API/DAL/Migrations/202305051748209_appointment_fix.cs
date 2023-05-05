namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointment_fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "ScheduleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "Status", c => c.String());
            AlterColumn("dbo.Appointments", "ScheduleTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "ScheduleTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "Status");
            DropColumn("dbo.Appointments", "ScheduleDate");
        }
    }
}

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leaveApplicationFix2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveApplications", "LeaveFrom", c => c.DateTime(nullable: false));
            AddColumn("dbo.LeaveApplications", "LeaveTill", c => c.DateTime(nullable: false));
            DropColumn("dbo.LeaveApplications", "LeaveDays");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LeaveApplications", "LeaveDays", c => c.Int(nullable: false));
            DropColumn("dbo.LeaveApplications", "LeaveTill");
            DropColumn("dbo.LeaveApplications", "LeaveFrom");
        }
    }
}

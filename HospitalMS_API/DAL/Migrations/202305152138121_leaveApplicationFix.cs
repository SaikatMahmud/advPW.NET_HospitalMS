namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leaveApplicationFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveApplications", "LeaveDays", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeaveApplications", "LeaveDays");
        }
    }
}

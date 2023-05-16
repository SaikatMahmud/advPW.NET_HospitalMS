namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leaveApplicationFix3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveApplications", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeaveApplications", "Status");
        }
    }
}

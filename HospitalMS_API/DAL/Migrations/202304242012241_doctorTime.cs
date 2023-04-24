namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctorTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "StayFrom", c => c.String());
            AlterColumn("dbo.Doctors", "StayTill", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "StayTill", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Doctors", "StayFrom", c => c.DateTime(nullable: false));
        }
    }
}

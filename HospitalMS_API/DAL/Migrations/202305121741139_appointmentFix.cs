namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointmentFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "PaidAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "PaidAmount");
        }
    }
}

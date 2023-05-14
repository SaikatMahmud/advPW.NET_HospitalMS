namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointmentFix1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Fee", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "PaidAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "PaidAmount", c => c.Int());
            DropColumn("dbo.Appointments", "Fee");
        }
    }
}

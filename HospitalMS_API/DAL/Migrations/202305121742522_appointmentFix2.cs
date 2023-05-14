namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointmentFix2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "PaidAmount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "PaidAmount", c => c.Int(nullable: false));
        }
    }
}

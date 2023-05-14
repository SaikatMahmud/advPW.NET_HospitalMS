namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class performDiagFix2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PerformDiags", "DeliverDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PerformDiags", "DeliverDate", c => c.DateTime(nullable: false));
        }
    }
}

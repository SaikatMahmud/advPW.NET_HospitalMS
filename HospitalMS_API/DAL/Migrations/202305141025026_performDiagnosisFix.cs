namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class performDiagnosisFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PerformDiags", "Cost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PerformDiags", "Cost");
        }
    }
}

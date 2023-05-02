namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ipdFix3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OPDBills", "BillAmount", c => c.Int(nullable: false));
            AlterColumn("dbo.OPDBills", "PaidAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OPDBills", "PaidAmount", c => c.Single(nullable: false));
            AlterColumn("dbo.OPDBills", "BillAmount", c => c.Single(nullable: false));
        }
    }
}

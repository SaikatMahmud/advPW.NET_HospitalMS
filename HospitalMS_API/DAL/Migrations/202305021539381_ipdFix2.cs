namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ipdFix2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IPDAdmits", "AdmitDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.IPDBills", "PaymentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IPDBills", "PaymentDate");
            DropColumn("dbo.IPDAdmits", "AdmitDate");
        }
    }
}

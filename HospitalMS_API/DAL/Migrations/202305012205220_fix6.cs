namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IPDBills", "IPDAdmitId", "dbo.IPDAdmits");
            DropIndex("dbo.IPDBills", new[] { "IPDAdmitId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.IPDBills", "IPDAdmitId");
            AddForeignKey("dbo.IPDBills", "IPDAdmitId", "dbo.IPDAdmits", "Id", cascadeDelete: true);
        }
    }
}

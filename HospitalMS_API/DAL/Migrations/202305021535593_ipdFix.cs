namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ipdFix : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.IPDBills", "IPDAdmitId");
            AddForeignKey("dbo.IPDBills", "IPDAdmitId", "dbo.IPDAdmits", "Id", cascadeDelete: false);
            DropColumn("dbo.IPDAdmits", "NameS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IPDAdmits", "NameS", c => c.String());
            DropForeignKey("dbo.IPDBills", "IPDAdmitId", "dbo.IPDAdmits");
            DropIndex("dbo.IPDBills", new[] { "IPDAdmitId" });
        }
    }
}

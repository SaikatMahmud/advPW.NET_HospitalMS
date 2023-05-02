namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IPDBills", "Id", "dbo.IPDAdmits");
            DropIndex("dbo.IPDBills", new[] { "Id" });
            DropPrimaryKey("dbo.IPDBills");
            AddColumn("dbo.IPDBills", "IPDAdmitId", c => c.Int(nullable: false));
            AlterColumn("dbo.IPDBills", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.IPDBills", "Id");
            CreateIndex("dbo.IPDBills", "IPDAdmitId");
            AddForeignKey("dbo.IPDBills", "IPDAdmitId", "dbo.IPDAdmits", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IPDBills", "IPDAdmitId", "dbo.IPDAdmits");
            DropIndex("dbo.IPDBills", new[] { "IPDAdmitId" });
            DropPrimaryKey("dbo.IPDBills");
            AlterColumn("dbo.IPDBills", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.IPDBills", "IPDAdmitId");
            AddPrimaryKey("dbo.IPDBills", "Id");
            CreateIndex("dbo.IPDBills", "Id");
            AddForeignKey("dbo.IPDBills", "Id", "dbo.IPDAdmits", "Id");
        }
    }
}

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IPDAdmits", "Id", "dbo.IPDBills");
            DropIndex("dbo.IPDAdmits", new[] { "Id" });
            DropPrimaryKey("dbo.IPDAdmits");
            DropPrimaryKey("dbo.IPDBills");
            AlterColumn("dbo.IPDAdmits", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.IPDBills", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.IPDAdmits", "Id");
            AddPrimaryKey("dbo.IPDBills", "Id");
            CreateIndex("dbo.IPDBills", "Id");
            AddForeignKey("dbo.IPDBills", "Id", "dbo.IPDAdmits", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IPDBills", "Id", "dbo.IPDAdmits");
            DropIndex("dbo.IPDBills", new[] { "Id" });
            DropPrimaryKey("dbo.IPDBills");
            DropPrimaryKey("dbo.IPDAdmits");
            AlterColumn("dbo.IPDBills", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.IPDAdmits", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.IPDBills", "Id");
            AddPrimaryKey("dbo.IPDAdmits", "Id");
            CreateIndex("dbo.IPDAdmits", "Id");
            AddForeignKey("dbo.IPDAdmits", "Id", "dbo.IPDBills", "Id");
        }
    }
}

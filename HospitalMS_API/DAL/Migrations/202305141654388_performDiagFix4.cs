namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class performDiagFix4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PerformDiags", "Id", "dbo.OPDBillDetails");
            DropIndex("dbo.PerformDiags", new[] { "Id" });
            DropPrimaryKey("dbo.PerformDiags");
            AlterColumn("dbo.PerformDiags", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PerformDiags", "Id");
            CreateIndex("dbo.OPDBillDetails", "PerformDiagId");
            AddForeignKey("dbo.OPDBillDetails", "PerformDiagId", "dbo.PerformDiags", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OPDBillDetails", "PerformDiagId", "dbo.PerformDiags");
            DropIndex("dbo.OPDBillDetails", new[] { "PerformDiagId" });
            DropPrimaryKey("dbo.PerformDiags");
            AlterColumn("dbo.PerformDiags", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PerformDiags", "Id");
            CreateIndex("dbo.PerformDiags", "Id");
            AddForeignKey("dbo.PerformDiags", "Id", "dbo.OPDBillDetails", "Id");
        }
    }
}

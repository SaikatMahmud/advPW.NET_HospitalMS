namespace HospitalMS_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.DiagLists", "DeptId");
            AddForeignKey("dbo.DiagLists", "DeptId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiagLists", "DeptId", "dbo.Departments");
            DropIndex("dbo.DiagLists", new[] { "DeptId" });
        }
    }
}

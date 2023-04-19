namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tokenUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "Type", c => c.String());
            AlterColumn("dbo.Tokens", "TKey", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tokens", "CreatedBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "CreatedBy", c => c.String());
            AlterColumn("dbo.Tokens", "TKey", c => c.String());
            DropColumn("dbo.Staffs", "Type");
        }
    }
}

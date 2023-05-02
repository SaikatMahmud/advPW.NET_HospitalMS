namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IPDAdmits", "Id", c => c.Int(nullable: false, identity: true));
        }

        public override void Down()
        {
        }
    }
}

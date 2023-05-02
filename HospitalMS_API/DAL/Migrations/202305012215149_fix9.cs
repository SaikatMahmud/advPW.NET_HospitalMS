namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IPDAdmits", "NameS", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IPDAdmits", "NameS");
        }
    }
}

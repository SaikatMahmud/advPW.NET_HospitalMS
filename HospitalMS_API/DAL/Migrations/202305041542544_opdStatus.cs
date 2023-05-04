namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opdStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OPDBills", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OPDBills", "Status");
        }
    }
}

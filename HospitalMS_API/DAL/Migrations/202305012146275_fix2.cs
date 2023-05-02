﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.IPDAdmits", "IPDName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IPDAdmits", "IPDName", c => c.String());
        }
    }
}

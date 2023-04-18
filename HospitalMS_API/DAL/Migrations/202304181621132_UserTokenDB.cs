namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTokenDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            AddColumn("dbo.Doctors", "Username", c => c.String());
            DropColumn("dbo.Admins", "Password");
            DropColumn("dbo.Admins", "Type");
            DropColumn("dbo.Patients", "Password");
            DropColumn("dbo.Patients", "Type");
            DropColumn("dbo.Staffs", "Password");
            DropColumn("dbo.Staffs", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "Type", c => c.String());
            AddColumn("dbo.Staffs", "Password", c => c.String());
            AddColumn("dbo.Patients", "Type", c => c.String());
            AddColumn("dbo.Patients", "Password", c => c.String());
            AddColumn("dbo.Admins", "Type", c => c.String());
            AddColumn("dbo.Admins", "Password", c => c.String());
            DropColumn("dbo.Doctors", "Username");
            DropTable("dbo.Users");
            DropTable("dbo.Tokens");
        }
    }
}

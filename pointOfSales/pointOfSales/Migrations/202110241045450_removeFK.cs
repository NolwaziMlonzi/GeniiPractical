namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleID" });
            AddColumn("dbo.Users", "Role", c => c.String());
            DropColumn("dbo.Users", "RoleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RoleID", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Role");
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
        }
    }
}

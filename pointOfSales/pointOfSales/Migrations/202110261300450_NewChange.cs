namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "TotalAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "TotalAmount", c => c.Double(nullable: false));
        }
    }
}

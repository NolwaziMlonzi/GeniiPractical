namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTotalAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "TotalAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "TotalAmount");
        }
    }
}

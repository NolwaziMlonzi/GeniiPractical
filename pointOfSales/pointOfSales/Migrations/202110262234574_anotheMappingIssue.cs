namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotheMappingIssue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "InvoiceID", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "Invoice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Invoice", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "InvoiceID");
        }
    }
}

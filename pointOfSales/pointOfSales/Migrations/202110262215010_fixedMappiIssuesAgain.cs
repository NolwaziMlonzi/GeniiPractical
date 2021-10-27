namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedMappiIssuesAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Items", new[] { "Invoice_InvoiceID" });
            AddColumn("dbo.Items", "Invoice", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "Invoice_InvoiceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Invoice_InvoiceID", c => c.Int());
            DropColumn("dbo.Items", "Invoice");
            CreateIndex("dbo.Items", "Invoice_InvoiceID");
            AddForeignKey("dbo.Items", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
        }
    }
}

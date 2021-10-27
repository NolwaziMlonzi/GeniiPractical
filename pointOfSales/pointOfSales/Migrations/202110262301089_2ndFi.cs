namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndFi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Products", new[] { "InvoiceID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Products", "InvoiceID");
            AddForeignKey("dbo.Products", "InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
        }
    }
}

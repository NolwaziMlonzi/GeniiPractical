namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productTableFixs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Products", new[] { "Invoice_InvoiceID" });
            RenameColumn(table: "dbo.Products", name: "Invoice_InvoiceID", newName: "InvoiceID");
            AlterColumn("dbo.Products", "InvoiceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "InvoiceID");
            AddForeignKey("dbo.Products", "InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Products", new[] { "InvoiceID" });
            AlterColumn("dbo.Products", "InvoiceID", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "InvoiceID", newName: "Invoice_InvoiceID");
            CreateIndex("dbo.Products", "Invoice_InvoiceID");
            AddForeignKey("dbo.Products", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
        }
    }
}

namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkTableProductAndInvoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Total = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            AddColumn("dbo.Products", "Invoice_InvoiceID", c => c.Int());
            CreateIndex("dbo.Products", "Invoice_InvoiceID");
            AddForeignKey("dbo.Products", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Products", new[] { "Invoice_InvoiceID" });
            DropColumn("dbo.Products", "Invoice_InvoiceID");
            DropTable("dbo.Invoices");
        }
    }
}

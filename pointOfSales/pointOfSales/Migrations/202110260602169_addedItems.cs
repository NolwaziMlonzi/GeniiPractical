namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        CostPerItem = c.Double(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        Invoice_InvoiceID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .Index(t => t.Invoice_InvoiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.Items", new[] { "Invoice_InvoiceID" });
            DropTable("dbo.Items");
        }
    }
}

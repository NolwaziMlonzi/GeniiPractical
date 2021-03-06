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
                        InvoiceID_InvoiceIDID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.InvoiceIDs", t => t.InvoiceID_InvoiceIDID)
                .Index(t => t.InvoiceID_InvoiceIDID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "InvoiceID_InvoiceIDID", "dbo.InvoiceIDs");
            DropIndex("dbo.Items", new[] { "InvoiceID_InvoiceIDID" });
            DropTable("dbo.Items");
        }
    }
}

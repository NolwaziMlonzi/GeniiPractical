namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkTableProductAndInvoiceID : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceIDs",
                c => new
                    {
                        InvoiceIDID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Total = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceIDID);
            
            AddColumn("dbo.Products", "InvoiceID_InvoiceIDID", c => c.Int());
            CreateIndex("dbo.Products", "InvoiceID_InvoiceIDID");
            AddForeignKey("dbo.Products", "InvoiceID_InvoiceIDID", "dbo.InvoiceIDs", "InvoiceIDID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "InvoiceID_InvoiceIDID", "dbo.InvoiceIDs");
            DropIndex("dbo.Products", new[] { "InvoiceID_InvoiceIDID" });
            DropColumn("dbo.Products", "InvoiceID_InvoiceIDID");
            DropTable("dbo.InvoiceIDs");
        }
    }
}

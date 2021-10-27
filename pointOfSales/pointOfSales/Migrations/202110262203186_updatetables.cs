namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetables : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "InvoiceID_InvoiceID", newName: "Invoice_InvoiceID");
            RenameIndex(table: "dbo.Items", name: "IX_InvoiceID_InvoiceID", newName: "IX_Invoice_InvoiceID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Items", name: "IX_Invoice_InvoiceID", newName: "IX_InvoiceID_InvoiceID");
            RenameColumn(table: "dbo.Items", name: "Invoice_InvoiceID", newName: "InvoiceID_InvoiceID");
        }
    }
}

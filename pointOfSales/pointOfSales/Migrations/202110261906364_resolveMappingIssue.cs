namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resolveMappingIssue : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "InvoiceID_InvoiceIDID_InvoiceIDID", newName: "InvoiceID_InvoiceIDID");
            RenameIndex(table: "dbo.Items", name: "IX_InvoiceID_InvoiceIDID_InvoiceIDID", newName: "IX_InvoiceID_InvoiceIDID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Items", name: "IX_InvoiceID_InvoiceIDID", newName: "IX_InvoiceID_InvoiceIDID_InvoiceIDID");
            RenameColumn(table: "dbo.Items", name: "InvoiceID_InvoiceIDID", newName: "InvoiceID_InvoiceIDID_InvoiceIDID");
        }
    }
}

namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDatatypeOfFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoiceIDs", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InvoiceIDs", "Total", c => c.String());
        }
    }
}

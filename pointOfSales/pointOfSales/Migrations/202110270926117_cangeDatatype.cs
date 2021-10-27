namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cangeDatatype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductItems", "Invoice_Id", c => c.Int(nullable: false));
            DropColumn("dbo.ProductItems", "InvoiceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductItems", "InvoiceID", c => c.Int(nullable: false));
            DropColumn("dbo.ProductItems", "Invoice_Id");
        }
    }
}

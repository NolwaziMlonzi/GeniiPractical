namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spellingEror : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductItems", "InvoiceID", c => c.Int(nullable: false));
            DropColumn("dbo.ProductItems", "InvoiceIID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductItems", "InvoiceIID", c => c.Int(nullable: false));
            DropColumn("dbo.ProductItems", "InvoiceID");
        }
    }
}

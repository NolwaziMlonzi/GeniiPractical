namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateCreatedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceIDs", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceIDs", "DateCreated");
        }
    }
}

namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateCreatedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "DateCreated");
        }
    }
}

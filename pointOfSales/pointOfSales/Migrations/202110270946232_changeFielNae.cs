namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFielNae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductItems", "Invoice_Id", c => c.Int(nullable: false));
            DropColumn("dbo.ProductItems", "Invoice_Unique_Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductItems", "Invoice_Unique_Value", c => c.Int(nullable: false));
            DropColumn("dbo.ProductItems", "Invoice_Id");
        }
    }
}

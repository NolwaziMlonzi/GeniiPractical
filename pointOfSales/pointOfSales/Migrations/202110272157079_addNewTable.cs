namespace pointOfSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsSolds",
                c => new
                    {
                        ProductSoldID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        sold = c.Double(nullable: false),
                        InStock = c.Double(nullable: false),
                        ReStock = c.Boolean(nullable: false),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductSoldID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsSolds", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.ProductsSolds", new[] { "Product_ProductID" });
            DropTable("dbo.ProductsSolds");
        }
    }
}

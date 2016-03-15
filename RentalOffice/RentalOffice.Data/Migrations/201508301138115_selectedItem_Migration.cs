namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class selectedItem_Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_OrderId" });
            CreateTable(
                "dbo.SelectedItems",
                c => new
                    {
                        SelectedItemId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.SelectedItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.Order_OrderId);
            
            AddColumn("dbo.Products", "Image", c => c.String());
            DropColumn("dbo.Products", "Order_OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Order_OrderId", c => c.Int());
            DropForeignKey("dbo.SelectedItems", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.SelectedItems", "ProductId", "dbo.Products");
            DropIndex("dbo.SelectedItems", new[] { "Order_OrderId" });
            DropIndex("dbo.SelectedItems", new[] { "ProductId" });
            DropColumn("dbo.Products", "Image");
            DropTable("dbo.SelectedItems");
            CreateIndex("dbo.Products", "Order_OrderId");
            AddForeignKey("dbo.Products", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}

namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        AddressId = c.Int(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        Payment = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AddressId);
            
            AddColumn("dbo.Products", "Order_OrderId", c => c.Int());
            AddColumn("dbo.Users", "Phone", c => c.String());
            CreateIndex("dbo.Products", "Order_OrderId");
            AddForeignKey("dbo.Products", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Products", new[] { "Order_OrderId" });
            DropIndex("dbo.Orders", new[] { "AddressId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Products", "Order_OrderId");
            DropTable("dbo.Orders");
        }
    }
}

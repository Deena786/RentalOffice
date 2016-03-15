namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderItem_Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SelectedItems", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.SelectedItems", new[] { "Order_OrderId" });
            AddColumn("dbo.Products", "Availability", c => c.Boolean());
            DropColumn("dbo.SelectedItems", "Order_OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SelectedItems", "Order_OrderId", c => c.Int());
            DropColumn("dbo.Products", "Availability");
            CreateIndex("dbo.SelectedItems", "Order_OrderId");
            AddForeignKey("dbo.SelectedItems", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}

namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_orderItem_Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int());
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}

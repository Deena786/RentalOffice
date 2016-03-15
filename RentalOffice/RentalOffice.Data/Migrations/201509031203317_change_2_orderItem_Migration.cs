namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_2_orderItem_Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "ProductName");
        }
    }
}

namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weird_Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Execution", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orders", "Payment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Payment", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "Execution");
        }
    }
}

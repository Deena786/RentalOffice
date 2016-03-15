namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_OrderProduct_2_Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Availability", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Availability", c => c.Boolean());
        }
    }
}

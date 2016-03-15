namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class address_userMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AddressId", c => c.Int(nullable: true));
            CreateIndex("dbo.Users", "AddressId");
            AddForeignKey("dbo.Users", "AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "AddressId" });
            DropColumn("dbo.Users", "AddressId");
        }
    }
}

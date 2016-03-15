namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_userMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "AddressId" });
            DropColumn("dbo.Users", "Birthday");
            DropColumn("dbo.Users", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Birthday", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Users", "AddressId");
            AddForeignKey("dbo.Users", "AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
    }
}

namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_Address_Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Addresses", "StreetId", "dbo.Streets");
            DropIndex("dbo.Addresses", new[] { "CityId" });
            DropIndex("dbo.Addresses", new[] { "StreetId" });
            AddColumn("dbo.Addresses", "City", c => c.String());
            AddColumn("dbo.Addresses", "Street", c => c.String());
            AlterColumn("dbo.Addresses", "Postcode", c => c.Int());
            AlterColumn("dbo.Addresses", "Apartment", c => c.Int());
            DropColumn("dbo.Addresses", "CityId");
            DropColumn("dbo.Addresses", "StreetId");
            DropTable("dbo.Cities");
            DropTable("dbo.Streets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        StreetId = c.Int(nullable: false, identity: true),
                        StreetName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StreetId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        СityId = c.Int(nullable: false, identity: true),
                        СityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.СityId);
            
            AddColumn("dbo.Addresses", "StreetId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "CityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "Apartment", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "Postcode", c => c.Int(nullable: false));
            DropColumn("dbo.Addresses", "Street");
            DropColumn("dbo.Addresses", "City");
            CreateIndex("dbo.Addresses", "StreetId");
            CreateIndex("dbo.Addresses", "CityId");
            AddForeignKey("dbo.Addresses", "StreetId", "dbo.Streets", "StreetId", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "CityId", "dbo.Cities", "СityId", cascadeDelete: true);
        }
    }
}

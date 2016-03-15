namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class address2Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Region = c.String(),
                        Postcode = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        StreetId = c.Int(nullable: false),
                        Building = c.String(),
                        Apartment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Streets", t => t.StreetId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.StreetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "StreetId", "dbo.Streets");
            DropForeignKey("dbo.Addresses", "CityId", "dbo.Cities");
            DropIndex("dbo.Addresses", new[] { "StreetId" });
            DropIndex("dbo.Addresses", new[] { "CityId" });
            DropTable("dbo.Addresses");
        }
    }
}

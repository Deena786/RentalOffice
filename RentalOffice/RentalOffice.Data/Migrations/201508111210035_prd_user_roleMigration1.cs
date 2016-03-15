namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prd_user_roleMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        СityId = c.Int(nullable: false, identity: true),
                        СityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.СityId);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        StreetId = c.Int(nullable: false, identity: true),
                        StreetName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StreetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Streets");
            DropTable("dbo.Cities");
        }
    }
}

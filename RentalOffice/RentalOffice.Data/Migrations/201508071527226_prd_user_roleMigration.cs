namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prd_user_roleMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Category = c.String(nullable: false, maxLength: 50),
                        Pledge = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 30),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Products");
        }
    }
}

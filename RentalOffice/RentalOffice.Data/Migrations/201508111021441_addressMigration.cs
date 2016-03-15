namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "Released", c => c.String(maxLength: 16));
            AddColumn("dbo.Products", "Made", c => c.String(maxLength: 32));
            AddColumn("dbo.Products", "Producer", c => c.String(maxLength: 32));
            AddColumn("dbo.Products", "FilmStars", c => c.String(maxLength: 256));
            AddColumn("dbo.Products", "Quality", c => c.String(maxLength: 32));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 512));
            AlterColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String());
            DropColumn("dbo.Products", "Quality");
            DropColumn("dbo.Products", "FilmStars");
            DropColumn("dbo.Products", "Producer");
            DropColumn("dbo.Products", "Made");
            DropColumn("dbo.Products", "Released");
            DropColumn("dbo.Products", "Price");
        }
    }
}

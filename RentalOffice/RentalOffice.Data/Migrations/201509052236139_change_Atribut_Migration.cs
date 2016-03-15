namespace RentalOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_Atribut_Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 8));
            
        }
        
        public override void Down()
        {
            
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
        }
    }
}

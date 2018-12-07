namespace SpaceUber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Review", "FirstName");
            DropColumn("dbo.Review", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Review", "FirstName", c => c.String(nullable: false));
        }
    }
}

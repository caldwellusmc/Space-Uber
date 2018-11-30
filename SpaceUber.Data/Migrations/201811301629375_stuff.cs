namespace SpaceUber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Review", "RiderId");
            DropColumn("dbo.Rider", "ReviewId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rider", "ReviewId", c => c.Int(nullable: false));
            AddColumn("dbo.Review", "RiderId", c => c.Int(nullable: false));
        }
    }
}

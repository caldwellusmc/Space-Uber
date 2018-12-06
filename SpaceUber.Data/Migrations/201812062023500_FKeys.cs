namespace SpaceUber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKeys : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Review", "DriverId");
            AddForeignKey("dbo.Review", "DriverId", "dbo.Driver", "DriverId", cascadeDelete: true);
            DropColumn("dbo.Driver", "ReviewId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Driver", "ReviewId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Review", "DriverId", "dbo.Driver");
            DropIndex("dbo.Review", new[] { "DriverId" });
        }
    }
}

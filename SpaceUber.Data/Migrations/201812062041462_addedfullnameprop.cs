namespace SpaceUber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfullnameprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Driver", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Driver", "FullName");
        }
    }
}

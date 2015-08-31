namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StationMaxLandingPadSizeString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stations", "MaxLandingPadSize", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stations", "MaxLandingPadSize");
        }
    }
}

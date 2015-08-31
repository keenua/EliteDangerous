namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamesEntitiesIndexes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Allegiances", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Economies", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Factions", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Governments", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.PowerControlFactions", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Securities", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.States", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.StationTypes", "Name", c => c.String(maxLength: 100));
            CreateIndex("dbo.Allegiances", "Name", name: "IX_AllegianceName");
            CreateIndex("dbo.Economies", "Name", name: "IX_EconomyName");
            CreateIndex("dbo.Factions", "Name", name: "IX_FactionName");
            CreateIndex("dbo.Governments", "Name", name: "IX_GovernmentName");
            CreateIndex("dbo.PowerControlFactions", "Name", name: "IX_PowerControlFactionName");
            CreateIndex("dbo.Securities", "Name", name: "IX_SecurityName");
            CreateIndex("dbo.States", "Name", name: "IX_StateName");
            CreateIndex("dbo.StationTypes", "Name", name: "IX_StationName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.StationTypes", "IX_StationName");
            DropIndex("dbo.States", "IX_StateName");
            DropIndex("dbo.Securities", "IX_SecurityName");
            DropIndex("dbo.PowerControlFactions", "IX_PowerControlFactionName");
            DropIndex("dbo.Governments", "IX_GovernmentName");
            DropIndex("dbo.Factions", "IX_FactionName");
            DropIndex("dbo.Economies", "IX_EconomyName");
            DropIndex("dbo.Allegiances", "IX_AllegianceName");
            AlterColumn("dbo.StationTypes", "Name", c => c.String());
            AlterColumn("dbo.States", "Name", c => c.String());
            AlterColumn("dbo.Securities", "Name", c => c.String());
            AlterColumn("dbo.PowerControlFactions", "Name", c => c.String());
            AlterColumn("dbo.Governments", "Name", c => c.String());
            AlterColumn("dbo.Factions", "Name", c => c.String());
            AlterColumn("dbo.Economies", "Name", c => c.String());
            AlterColumn("dbo.Allegiances", "Name", c => c.String());
        }
    }
}

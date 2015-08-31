namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIdentityForNamedEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Systems", "AllegianceId", "dbo.Allegiances");
            DropForeignKey("dbo.Systems", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.Systems", "GovernmentId", "dbo.Governments");
            DropForeignKey("dbo.Systems", "PowerControlFactionId", "dbo.PowerControlFactions");
            DropForeignKey("dbo.Systems", "PrimaryEconomyId", "dbo.Economies");
            DropForeignKey("dbo.Systems", "SecurityId", "dbo.Securities");
            DropForeignKey("dbo.Systems", "StateId", "dbo.States");
            DropPrimaryKey("dbo.Allegiances");
            DropPrimaryKey("dbo.Factions");
            DropPrimaryKey("dbo.Governments");
            DropPrimaryKey("dbo.PowerControlFactions");
            DropPrimaryKey("dbo.Economies");
            DropPrimaryKey("dbo.Securities");
            DropPrimaryKey("dbo.States");
            AlterColumn("dbo.Allegiances", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Factions", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Governments", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PowerControlFactions", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Economies", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Securities", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.States", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Allegiances", "Id");
            AddPrimaryKey("dbo.Factions", "Id");
            AddPrimaryKey("dbo.Governments", "Id");
            AddPrimaryKey("dbo.PowerControlFactions", "Id");
            AddPrimaryKey("dbo.Economies", "Id");
            AddPrimaryKey("dbo.Securities", "Id");
            AddPrimaryKey("dbo.States", "Id");
            AddForeignKey("dbo.Systems", "AllegianceId", "dbo.Allegiances", "Id");
            AddForeignKey("dbo.Systems", "FactionId", "dbo.Factions", "Id");
            AddForeignKey("dbo.Systems", "GovernmentId", "dbo.Governments", "Id");
            AddForeignKey("dbo.Systems", "PowerControlFactionId", "dbo.PowerControlFactions", "Id");
            AddForeignKey("dbo.Systems", "PrimaryEconomyId", "dbo.Economies", "Id");
            AddForeignKey("dbo.Systems", "SecurityId", "dbo.Securities", "Id");
            AddForeignKey("dbo.Systems", "StateId", "dbo.States", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Systems", "StateId", "dbo.States");
            DropForeignKey("dbo.Systems", "SecurityId", "dbo.Securities");
            DropForeignKey("dbo.Systems", "PrimaryEconomyId", "dbo.Economies");
            DropForeignKey("dbo.Systems", "PowerControlFactionId", "dbo.PowerControlFactions");
            DropForeignKey("dbo.Systems", "GovernmentId", "dbo.Governments");
            DropForeignKey("dbo.Systems", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.Systems", "AllegianceId", "dbo.Allegiances");
            DropPrimaryKey("dbo.States");
            DropPrimaryKey("dbo.Securities");
            DropPrimaryKey("dbo.Economies");
            DropPrimaryKey("dbo.PowerControlFactions");
            DropPrimaryKey("dbo.Governments");
            DropPrimaryKey("dbo.Factions");
            DropPrimaryKey("dbo.Allegiances");
            AlterColumn("dbo.States", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Securities", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Economies", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PowerControlFactions", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Governments", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Factions", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Allegiances", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.States", "Id");
            AddPrimaryKey("dbo.Securities", "Id");
            AddPrimaryKey("dbo.Economies", "Id");
            AddPrimaryKey("dbo.PowerControlFactions", "Id");
            AddPrimaryKey("dbo.Governments", "Id");
            AddPrimaryKey("dbo.Factions", "Id");
            AddPrimaryKey("dbo.Allegiances", "Id");
            AddForeignKey("dbo.Systems", "StateId", "dbo.States", "Id");
            AddForeignKey("dbo.Systems", "SecurityId", "dbo.Securities", "Id");
            AddForeignKey("dbo.Systems", "PrimaryEconomyId", "dbo.Economies", "Id");
            AddForeignKey("dbo.Systems", "PowerControlFactionId", "dbo.PowerControlFactions", "Id");
            AddForeignKey("dbo.Systems", "GovernmentId", "dbo.Governments", "Id");
            AddForeignKey("dbo.Systems", "FactionId", "dbo.Factions", "Id");
            AddForeignKey("dbo.Systems", "AllegianceId", "dbo.Allegiances", "Id");
        }
    }
}

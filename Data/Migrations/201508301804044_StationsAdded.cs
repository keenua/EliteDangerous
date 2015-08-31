namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StationsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        SystemId = c.Int(nullable: false),
                        DistanceToStar = c.Long(),
                        FactionId = c.Int(),
                        GovernmentId = c.Int(),
                        AllegianceId = c.Int(),
                        StateId = c.Int(),
                        StationTypeId = c.Int(),
                        HasBlackMarket = c.Boolean(nullable: false),
                        HasCommodities = c.Boolean(nullable: false),
                        HasRefuel = c.Boolean(nullable: false),
                        HasRepair = c.Boolean(nullable: false),
                        HasRearm = c.Boolean(nullable: false),
                        HasOutfitting = c.Boolean(nullable: false),
                        HasShipyard = c.Boolean(nullable: false),
                        UpdatedAt = c.Long(nullable: false),
                        Commodity_Id = c.Int(),
                        Commodity_Id1 = c.Int(),
                        Commodity_Id2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Allegiances", t => t.AllegianceId)
                .ForeignKey("dbo.Commodities", t => t.Commodity_Id)
                .ForeignKey("dbo.Commodities", t => t.Commodity_Id1)
                .ForeignKey("dbo.Commodities", t => t.Commodity_Id2)
                .ForeignKey("dbo.Factions", t => t.FactionId)
                .ForeignKey("dbo.Governments", t => t.GovernmentId)
                .ForeignKey("dbo.States", t => t.StateId)
                .ForeignKey("dbo.StationTypes", t => t.StationTypeId)
                .ForeignKey("dbo.Systems", t => t.SystemId, cascadeDelete: true)
                .Index(t => t.SystemId)
                .Index(t => t.FactionId)
                .Index(t => t.GovernmentId)
                .Index(t => t.AllegianceId)
                .Index(t => t.StateId)
                .Index(t => t.StationTypeId)
                .Index(t => t.Commodity_Id)
                .Index(t => t.Commodity_Id1)
                .Index(t => t.Commodity_Id2);
            
            CreateTable(
                "dbo.StationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EconomyStations",
                c => new
                    {
                        Economy_Id = c.Int(nullable: false),
                        Station_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Economy_Id, t.Station_Id })
                .ForeignKey("dbo.Economies", t => t.Economy_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.Station_Id, cascadeDelete: true)
                .Index(t => t.Economy_Id)
                .Index(t => t.Station_Id);
            
            AddColumn("dbo.Commodities", "Station_Id", c => c.Int());
            AddColumn("dbo.Commodities", "Station_Id1", c => c.Int());
            AddColumn("dbo.Commodities", "Station_Id2", c => c.Int());
            CreateIndex("dbo.Commodities", "Station_Id");
            CreateIndex("dbo.Commodities", "Station_Id1");
            CreateIndex("dbo.Commodities", "Station_Id2");
            AddForeignKey("dbo.Commodities", "Station_Id", "dbo.Stations", "Id");
            AddForeignKey("dbo.Commodities", "Station_Id1", "dbo.Stations", "Id");
            AddForeignKey("dbo.Commodities", "Station_Id2", "dbo.Stations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stations", "SystemId", "dbo.Systems");
            DropForeignKey("dbo.Stations", "StationTypeId", "dbo.StationTypes");
            DropForeignKey("dbo.Stations", "StateId", "dbo.States");
            DropForeignKey("dbo.Commodities", "Station_Id2", "dbo.Stations");
            DropForeignKey("dbo.Commodities", "Station_Id1", "dbo.Stations");
            DropForeignKey("dbo.Stations", "GovernmentId", "dbo.Governments");
            DropForeignKey("dbo.Stations", "FactionId", "dbo.Factions");
            DropForeignKey("dbo.Commodities", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.Stations", "Commodity_Id2", "dbo.Commodities");
            DropForeignKey("dbo.Stations", "Commodity_Id1", "dbo.Commodities");
            DropForeignKey("dbo.Stations", "Commodity_Id", "dbo.Commodities");
            DropForeignKey("dbo.EconomyStations", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.EconomyStations", "Economy_Id", "dbo.Economies");
            DropForeignKey("dbo.Stations", "AllegianceId", "dbo.Allegiances");
            DropIndex("dbo.EconomyStations", new[] { "Station_Id" });
            DropIndex("dbo.EconomyStations", new[] { "Economy_Id" });
            DropIndex("dbo.Commodities", new[] { "Station_Id2" });
            DropIndex("dbo.Commodities", new[] { "Station_Id1" });
            DropIndex("dbo.Commodities", new[] { "Station_Id" });
            DropIndex("dbo.Stations", new[] { "Commodity_Id2" });
            DropIndex("dbo.Stations", new[] { "Commodity_Id1" });
            DropIndex("dbo.Stations", new[] { "Commodity_Id" });
            DropIndex("dbo.Stations", new[] { "StationTypeId" });
            DropIndex("dbo.Stations", new[] { "StateId" });
            DropIndex("dbo.Stations", new[] { "AllegianceId" });
            DropIndex("dbo.Stations", new[] { "GovernmentId" });
            DropIndex("dbo.Stations", new[] { "FactionId" });
            DropIndex("dbo.Stations", new[] { "SystemId" });
            DropColumn("dbo.Commodities", "Station_Id2");
            DropColumn("dbo.Commodities", "Station_Id1");
            DropColumn("dbo.Commodities", "Station_Id");
            DropTable("dbo.EconomyStations");
            DropTable("dbo.StationTypes");
            DropTable("dbo.Stations");
        }
    }
}

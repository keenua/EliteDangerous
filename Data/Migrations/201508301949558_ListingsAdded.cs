namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListingsAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EconomyStations", newName: "StationsEconomies");
            RenameTable(name: "dbo.CommodityStations", newName: "ExportCommodities");
            RenameTable(name: "dbo.CommodityStation1", newName: "ImportCommodities");
            RenameTable(name: "dbo.CommodityStation2", newName: "ProhibitedCommodities");
            RenameColumn(table: "dbo.StationsEconomies", name: "Economy_Id", newName: "EconomyId");
            RenameColumn(table: "dbo.StationsEconomies", name: "Station_Id", newName: "StationId");
            RenameColumn(table: "dbo.ExportCommodities", name: "Commodity_Id", newName: "CommodityId");
            RenameColumn(table: "dbo.ExportCommodities", name: "Station_Id", newName: "StationId");
            RenameColumn(table: "dbo.ImportCommodities", name: "Commodity_Id", newName: "CommodityId");
            RenameColumn(table: "dbo.ImportCommodities", name: "Station_Id", newName: "StationId");
            RenameColumn(table: "dbo.ProhibitedCommodities", name: "Commodity_Id", newName: "CommodityId");
            RenameColumn(table: "dbo.ProhibitedCommodities", name: "Station_Id", newName: "StationId");
            RenameIndex(table: "dbo.StationsEconomies", name: "IX_Station_Id", newName: "IX_StationId");
            RenameIndex(table: "dbo.StationsEconomies", name: "IX_Economy_Id", newName: "IX_EconomyId");
            RenameIndex(table: "dbo.ExportCommodities", name: "IX_Station_Id", newName: "IX_StationId");
            RenameIndex(table: "dbo.ExportCommodities", name: "IX_Commodity_Id", newName: "IX_CommodityId");
            RenameIndex(table: "dbo.ImportCommodities", name: "IX_Station_Id", newName: "IX_StationId");
            RenameIndex(table: "dbo.ImportCommodities", name: "IX_Commodity_Id", newName: "IX_CommodityId");
            RenameIndex(table: "dbo.ProhibitedCommodities", name: "IX_Station_Id", newName: "IX_StationId");
            RenameIndex(table: "dbo.ProhibitedCommodities", name: "IX_Commodity_Id", newName: "IX_CommodityId");
            DropPrimaryKey("dbo.StationsEconomies");
            DropPrimaryKey("dbo.ExportCommodities");
            DropPrimaryKey("dbo.ImportCommodities");
            DropPrimaryKey("dbo.ProhibitedCommodities");
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StationId = c.Int(nullable: false),
                        CommodityId = c.Int(nullable: false),
                        Supply = c.Int(),
                        BuyPrice = c.Int(),
                        SellPrice = c.Int(),
                        Demand = c.Int(),
                        CollectedAt = c.Long(nullable: false),
                        UpdateCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commodities", t => t.CommodityId, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.StationId, cascadeDelete: true)
                .Index(t => t.StationId)
                .Index(t => t.CommodityId);
            
            AddPrimaryKey("dbo.StationsEconomies", new[] { "StationId", "EconomyId" });
            AddPrimaryKey("dbo.ExportCommodities", new[] { "StationId", "CommodityId" });
            AddPrimaryKey("dbo.ImportCommodities", new[] { "StationId", "CommodityId" });
            AddPrimaryKey("dbo.ProhibitedCommodities", new[] { "StationId", "CommodityId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listings", "StationId", "dbo.Stations");
            DropForeignKey("dbo.Listings", "CommodityId", "dbo.Commodities");
            DropIndex("dbo.Listings", new[] { "CommodityId" });
            DropIndex("dbo.Listings", new[] { "StationId" });
            DropPrimaryKey("dbo.ProhibitedCommodities");
            DropPrimaryKey("dbo.ImportCommodities");
            DropPrimaryKey("dbo.ExportCommodities");
            DropPrimaryKey("dbo.StationsEconomies");
            DropTable("dbo.Listings");
            AddPrimaryKey("dbo.ProhibitedCommodities", new[] { "Commodity_Id", "Station_Id" });
            AddPrimaryKey("dbo.ImportCommodities", new[] { "Commodity_Id", "Station_Id" });
            AddPrimaryKey("dbo.ExportCommodities", new[] { "Commodity_Id", "Station_Id" });
            AddPrimaryKey("dbo.StationsEconomies", new[] { "Economy_Id", "Station_Id" });
            RenameIndex(table: "dbo.ProhibitedCommodities", name: "IX_CommodityId", newName: "IX_Commodity_Id");
            RenameIndex(table: "dbo.ProhibitedCommodities", name: "IX_StationId", newName: "IX_Station_Id");
            RenameIndex(table: "dbo.ImportCommodities", name: "IX_CommodityId", newName: "IX_Commodity_Id");
            RenameIndex(table: "dbo.ImportCommodities", name: "IX_StationId", newName: "IX_Station_Id");
            RenameIndex(table: "dbo.ExportCommodities", name: "IX_CommodityId", newName: "IX_Commodity_Id");
            RenameIndex(table: "dbo.ExportCommodities", name: "IX_StationId", newName: "IX_Station_Id");
            RenameIndex(table: "dbo.StationsEconomies", name: "IX_EconomyId", newName: "IX_Economy_Id");
            RenameIndex(table: "dbo.StationsEconomies", name: "IX_StationId", newName: "IX_Station_Id");
            RenameColumn(table: "dbo.ProhibitedCommodities", name: "StationId", newName: "Station_Id");
            RenameColumn(table: "dbo.ProhibitedCommodities", name: "CommodityId", newName: "Commodity_Id");
            RenameColumn(table: "dbo.ImportCommodities", name: "StationId", newName: "Station_Id");
            RenameColumn(table: "dbo.ImportCommodities", name: "CommodityId", newName: "Commodity_Id");
            RenameColumn(table: "dbo.ExportCommodities", name: "StationId", newName: "Station_Id");
            RenameColumn(table: "dbo.ExportCommodities", name: "CommodityId", newName: "Commodity_Id");
            RenameColumn(table: "dbo.StationsEconomies", name: "StationId", newName: "Station_Id");
            RenameColumn(table: "dbo.StationsEconomies", name: "EconomyId", newName: "Economy_Id");
            RenameTable(name: "dbo.ProhibitedCommodities", newName: "CommodityStation2");
            RenameTable(name: "dbo.ImportCommodities", newName: "CommodityStation1");
            RenameTable(name: "dbo.ExportCommodities", newName: "CommodityStations");
            RenameTable(name: "dbo.StationsEconomies", newName: "EconomyStations");
        }
    }
}

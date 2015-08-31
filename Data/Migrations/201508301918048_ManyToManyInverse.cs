namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyInverse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stations", "Commodity_Id", "dbo.Commodities");
            DropForeignKey("dbo.Stations", "Commodity_Id1", "dbo.Commodities");
            DropForeignKey("dbo.Stations", "Commodity_Id2", "dbo.Commodities");
            DropForeignKey("dbo.Commodities", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.Commodities", "Station_Id1", "dbo.Stations");
            DropForeignKey("dbo.Commodities", "Station_Id2", "dbo.Stations");
            DropIndex("dbo.Stations", new[] { "Commodity_Id" });
            DropIndex("dbo.Stations", new[] { "Commodity_Id1" });
            DropIndex("dbo.Stations", new[] { "Commodity_Id2" });
            DropIndex("dbo.Commodities", new[] { "Station_Id" });
            DropIndex("dbo.Commodities", new[] { "Station_Id1" });
            DropIndex("dbo.Commodities", new[] { "Station_Id2" });
            CreateTable(
                "dbo.CommodityStations",
                c => new
                    {
                        Commodity_Id = c.Int(nullable: false),
                        Station_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Commodity_Id, t.Station_Id })
                .ForeignKey("dbo.Commodities", t => t.Commodity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.Station_Id, cascadeDelete: true)
                .Index(t => t.Commodity_Id)
                .Index(t => t.Station_Id);
            
            CreateTable(
                "dbo.CommodityStation1",
                c => new
                    {
                        Commodity_Id = c.Int(nullable: false),
                        Station_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Commodity_Id, t.Station_Id })
                .ForeignKey("dbo.Commodities", t => t.Commodity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.Station_Id, cascadeDelete: true)
                .Index(t => t.Commodity_Id)
                .Index(t => t.Station_Id);
            
            CreateTable(
                "dbo.CommodityStation2",
                c => new
                    {
                        Commodity_Id = c.Int(nullable: false),
                        Station_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Commodity_Id, t.Station_Id })
                .ForeignKey("dbo.Commodities", t => t.Commodity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.Station_Id, cascadeDelete: true)
                .Index(t => t.Commodity_Id)
                .Index(t => t.Station_Id);
            
            DropColumn("dbo.Stations", "Commodity_Id");
            DropColumn("dbo.Stations", "Commodity_Id1");
            DropColumn("dbo.Stations", "Commodity_Id2");
            DropColumn("dbo.Commodities", "Station_Id");
            DropColumn("dbo.Commodities", "Station_Id1");
            DropColumn("dbo.Commodities", "Station_Id2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Commodities", "Station_Id2", c => c.Int());
            AddColumn("dbo.Commodities", "Station_Id1", c => c.Int());
            AddColumn("dbo.Commodities", "Station_Id", c => c.Int());
            AddColumn("dbo.Stations", "Commodity_Id2", c => c.Int());
            AddColumn("dbo.Stations", "Commodity_Id1", c => c.Int());
            AddColumn("dbo.Stations", "Commodity_Id", c => c.Int());
            DropForeignKey("dbo.CommodityStation2", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.CommodityStation2", "Commodity_Id", "dbo.Commodities");
            DropForeignKey("dbo.CommodityStation1", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.CommodityStation1", "Commodity_Id", "dbo.Commodities");
            DropForeignKey("dbo.CommodityStations", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.CommodityStations", "Commodity_Id", "dbo.Commodities");
            DropIndex("dbo.CommodityStation2", new[] { "Station_Id" });
            DropIndex("dbo.CommodityStation2", new[] { "Commodity_Id" });
            DropIndex("dbo.CommodityStation1", new[] { "Station_Id" });
            DropIndex("dbo.CommodityStation1", new[] { "Commodity_Id" });
            DropIndex("dbo.CommodityStations", new[] { "Station_Id" });
            DropIndex("dbo.CommodityStations", new[] { "Commodity_Id" });
            DropTable("dbo.CommodityStation2");
            DropTable("dbo.CommodityStation1");
            DropTable("dbo.CommodityStations");
            CreateIndex("dbo.Commodities", "Station_Id2");
            CreateIndex("dbo.Commodities", "Station_Id1");
            CreateIndex("dbo.Commodities", "Station_Id");
            CreateIndex("dbo.Stations", "Commodity_Id2");
            CreateIndex("dbo.Stations", "Commodity_Id1");
            CreateIndex("dbo.Stations", "Commodity_Id");
            AddForeignKey("dbo.Commodities", "Station_Id2", "dbo.Stations", "Id");
            AddForeignKey("dbo.Commodities", "Station_Id1", "dbo.Stations", "Id");
            AddForeignKey("dbo.Commodities", "Station_Id", "dbo.Stations", "Id");
            AddForeignKey("dbo.Stations", "Commodity_Id2", "dbo.Commodities", "Id");
            AddForeignKey("dbo.Stations", "Commodity_Id1", "dbo.Commodities", "Id");
            AddForeignKey("dbo.Stations", "Commodity_Id", "dbo.Commodities", "Id");
        }
    }
}

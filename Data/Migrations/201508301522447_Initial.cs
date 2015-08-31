namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commodities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommodityCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.CommodityAveragePrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        CommodityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commodities", t => t.CommodityId, cascadeDelete: true)
                .Index(t => t.CommodityId);
            
            CreateTable(
                "dbo.CommodityCategories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commodities", "CategoryId", "dbo.CommodityCategories");
            DropForeignKey("dbo.CommodityAveragePrices", "CommodityId", "dbo.Commodities");
            DropIndex("dbo.CommodityAveragePrices", new[] { "CommodityId" });
            DropIndex("dbo.Commodities", new[] { "CategoryId" });
            DropTable("dbo.CommodityCategories");
            DropTable("dbo.CommodityAveragePrices");
            DropTable("dbo.Commodities");
        }
    }
}

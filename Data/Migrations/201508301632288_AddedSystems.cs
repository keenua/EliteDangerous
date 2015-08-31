namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSystems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allegiances",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Systems",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Z = c.Double(nullable: false),
                        FactionId = c.Int(),
                        Population = c.Long(nullable: false),
                        GovernmentId = c.Int(),
                        AllegianceId = c.Int(),
                        StateId = c.Int(),
                        SecurityId = c.Int(),
                        PrimaryEconomyId = c.Int(),
                        NeedsPermit = c.Boolean(nullable: false),
                        UpdatedAt = c.Long(nullable: false),
                        PowerControlFactionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factions", t => t.FactionId)
                .ForeignKey("dbo.Governments", t => t.GovernmentId)
                .ForeignKey("dbo.PowerControlFactions", t => t.PowerControlFactionId)
                .ForeignKey("dbo.Economies", t => t.PrimaryEconomyId)
                .ForeignKey("dbo.Securities", t => t.SecurityId)
                .ForeignKey("dbo.States", t => t.StateId)
                .ForeignKey("dbo.Allegiances", t => t.AllegianceId)
                .Index(t => t.FactionId)
                .Index(t => t.GovernmentId)
                .Index(t => t.AllegianceId)
                .Index(t => t.StateId)
                .Index(t => t.SecurityId)
                .Index(t => t.PrimaryEconomyId)
                .Index(t => t.PowerControlFactionId);
            
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Governments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PowerControlFactions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Economies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Securities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Systems", "AllegianceId", "dbo.Allegiances");
            DropForeignKey("dbo.Systems", "StateId", "dbo.States");
            DropForeignKey("dbo.Systems", "SecurityId", "dbo.Securities");
            DropForeignKey("dbo.Systems", "PrimaryEconomyId", "dbo.Economies");
            DropForeignKey("dbo.Systems", "PowerControlFactionId", "dbo.PowerControlFactions");
            DropForeignKey("dbo.Systems", "GovernmentId", "dbo.Governments");
            DropForeignKey("dbo.Systems", "FactionId", "dbo.Factions");
            DropIndex("dbo.Systems", new[] { "PowerControlFactionId" });
            DropIndex("dbo.Systems", new[] { "PrimaryEconomyId" });
            DropIndex("dbo.Systems", new[] { "SecurityId" });
            DropIndex("dbo.Systems", new[] { "StateId" });
            DropIndex("dbo.Systems", new[] { "AllegianceId" });
            DropIndex("dbo.Systems", new[] { "GovernmentId" });
            DropIndex("dbo.Systems", new[] { "FactionId" });
            DropTable("dbo.States");
            DropTable("dbo.Securities");
            DropTable("dbo.Economies");
            DropTable("dbo.PowerControlFactions");
            DropTable("dbo.Governments");
            DropTable("dbo.Factions");
            DropTable("dbo.Systems");
            DropTable("dbo.Allegiances");
        }
    }
}

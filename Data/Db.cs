using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using Data.Commodities;
using Data.Stations;
using Data.Systems;
using System = Data.Systems.System;

namespace Data
{
    public class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<CommodityCategory> CommodityCategories { get; set; }
        public DbSet<CommodityAveragePrice> CommodityAveragePrices { get; set; }

        public DbSet<Allegiance> Allegiances { get; set; }
        public DbSet<Economy> Economies { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Government> Governments { get; set; }
        public DbSet<PowerControlFaction> PowerControlFactions { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Systems.System> Systems { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<StationType> StationTypes { get; set; }
        public DbSet<Listing> Listings { get; set; }

        private void BuildSystem(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allegiance>()
                .HasMany(x => x.Systems)
                .WithOptional(x => x.Allegiance)
                .HasForeignKey(x => x.AllegianceId);

            modelBuilder.Entity<Economy>()
                .HasMany(x => x.Systems)
                .WithOptional(x => x.PrimaryEconomy)
                .HasForeignKey(x => x.PrimaryEconomyId);

            modelBuilder.Entity<Faction>()
                .HasMany(x => x.Systems)
                .WithOptional(x => x.Faction)
                .HasForeignKey(x => x.FactionId);

            modelBuilder.Entity<Government>()
                .HasMany(x => x.Systems)
                .WithOptional(x => x.Government)
                .HasForeignKey(x => x.GovernmentId);

            modelBuilder.Entity<PowerControlFaction>()
                .HasMany(x => x.Systems)
                .WithOptional(x => x.PowerControlFaction)
                .HasForeignKey(x => x.PowerControlFactionId);

            modelBuilder.Entity<Security>()
                .HasMany(x => x.Systems)
                .WithOptional(x => x.Security)
                .HasForeignKey(x => x.SecurityId);

            modelBuilder.Entity<State>()
                .HasMany(x => x.Systems)
                .WithOptional(x => x.State)
                .HasForeignKey(x => x.StateId);
        }

        private void BuildStation(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Systems.System>()
                .HasMany(x => x.Stations)
                .WithRequired(x => x.System)
                .HasForeignKey(x => x.SystemId);

            modelBuilder.Entity<Faction>()
                .HasMany(x => x.Stations)
                .WithOptional(x => x.Faction)
                .HasForeignKey(x => x.FactionId);

            modelBuilder.Entity<Government>()
                .HasMany(x => x.Stations)
                .WithOptional(x => x.Government)
                .HasForeignKey(x => x.GovernmentId);

            modelBuilder.Entity<Allegiance>()
                .HasMany(x => x.Stations)
                .WithOptional(x => x.Allegiance)
                .HasForeignKey(x => x.AllegianceId);

            modelBuilder.Entity<State>()
                .HasMany(x => x.Stations)
                .WithOptional(x => x.State)
                .HasForeignKey(x => x.StateId);

            modelBuilder.Entity<StationType>()
                .HasMany(x => x.Stations)
                .WithOptional(x => x.StationType)
                .HasForeignKey(x => x.StationTypeId);

            modelBuilder.Entity<Station>()
                .HasMany(x => x.ImportCommodities)
                .WithMany(x => x.StationsImport)
                .Map(sc =>
                {
                    sc.MapLeftKey("StationId");
                    sc.MapRightKey("CommodityId");
                    sc.ToTable("ImportCommodities");
                });

            modelBuilder.Entity<Station>()
                .HasMany(x => x.ExportCommodities)
                .WithMany(x => x.StationsExport)
                .Map(sc =>
                {
                    sc.MapLeftKey("StationId");
                    sc.MapRightKey("CommodityId");
                    sc.ToTable("ExportCommodities");
                });

            modelBuilder.Entity<Station>()
                .HasMany(x => x.ProhibitedCommodities)
                .WithMany(x => x.StationsProhibit)
                .Map(sc =>
                {
                    sc.MapLeftKey("StationId");
                    sc.MapRightKey("CommodityId");
                    sc.ToTable("ProhibitedCommodities");
                });

            modelBuilder.Entity<Station>()
                .HasMany(x => x.Economies)
                .WithMany(x => x.Stations)
                .Map(sc =>
                {
                    sc.MapLeftKey("StationId");
                    sc.MapRightKey("EconomyId");
                    sc.ToTable("StationsEconomies");
                });

            modelBuilder.Entity<Station>()
                .HasMany(x => x.Listings)
                .WithRequired(x => x.Station)
                .HasForeignKey(x => x.StationId);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commodity>()
                .HasMany(x => x.AveragePrices)
                .WithRequired(x => x.Commodity)
                .HasForeignKey(x => x.CommodityId);

            modelBuilder.Entity<CommodityCategory>()
                .HasMany(x => x.Commodities)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            BuildStation(modelBuilder);
            BuildSystem(modelBuilder);
        }
    }
}
namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemPopulationNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Systems", "Population", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Systems", "Population", c => c.Long(nullable: false));
        }
    }
}

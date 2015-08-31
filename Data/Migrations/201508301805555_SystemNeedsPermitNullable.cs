namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemNeedsPermitNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Systems", "NeedsPermit", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Systems", "NeedsPermit", c => c.Boolean(nullable: false));
        }
    }
}

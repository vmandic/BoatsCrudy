namespace BoatsCrudy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boat", "ProductionYear", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boat", "ProductionYear", c => c.Boolean(nullable: false));
        }
    }
}

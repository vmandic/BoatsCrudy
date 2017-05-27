namespace BoatsCrudy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BoatOwner", "Firstname", c => c.String(nullable: false));
            AlterColumn("dbo.BoatOwner", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.BoatOwner", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Trip", "StartingPort", c => c.String(nullable: false));
            AlterColumn("dbo.Trip", "DestinationPort", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trip", "DestinationPort", c => c.String());
            AlterColumn("dbo.Trip", "StartingPort", c => c.String());
            AlterColumn("dbo.BoatOwner", "Email", c => c.String());
            AlterColumn("dbo.BoatOwner", "Lastname", c => c.String());
            AlterColumn("dbo.BoatOwner", "Firstname", c => c.String());
        }
    }
}

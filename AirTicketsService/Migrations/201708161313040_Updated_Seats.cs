namespace AirTicketsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Seats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeatModels", "FlightID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SeatModels", "FlightID");
        }
    }
}

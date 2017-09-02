namespace AirTicketsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Tickets_Flights_Seats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeatModels", "isFree", c => c.Boolean(nullable: false));
            DropColumn("dbo.SeatModels", "FlightsID");
            DropColumn("dbo.SeatModels", "FreeSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SeatModels", "FreeSeats", c => c.String());
            AddColumn("dbo.SeatModels", "FlightsID", c => c.String());
            DropColumn("dbo.SeatModels", "isFree");
        }
    }
}

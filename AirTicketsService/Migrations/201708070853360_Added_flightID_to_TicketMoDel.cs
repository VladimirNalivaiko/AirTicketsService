namespace AirTicketsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_flightID_to_TicketMoDel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketModels", "FlightID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketModels", "FlightID");
        }
    }
}

namespace AirTicketsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Flight_and_Ticket_Models : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightModels", "TimeOfFlight", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.FlightModels", "DeparturePlace", c => c.String(nullable: false));
            AlterColumn("dbo.FlightModels", "ArrivalPlace", c => c.String(nullable: false));
            AlterColumn("dbo.TicketModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.TicketModels", "SurName", c => c.String(nullable: false));
            AlterColumn("dbo.TicketModels", "PassportNumber", c => c.String(nullable: false));
            AlterColumn("dbo.TicketModels", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.TicketModels", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {           
            AlterColumn("dbo.TicketModels", "Email", c => c.String());
            AlterColumn("dbo.TicketModels", "PhoneNumber", c => c.String());
            AlterColumn("dbo.TicketModels", "PassportNumber", c => c.String());
            AlterColumn("dbo.TicketModels", "SurName", c => c.String());
            AlterColumn("dbo.TicketModels", "Name", c => c.String());
            AlterColumn("dbo.FlightModels", "ArrivalPlace", c => c.String());
            AlterColumn("dbo.FlightModels", "DeparturePlace", c => c.String());
            DropColumn("dbo.FlightModels", "TimeOfFlight");
        }
    }
}

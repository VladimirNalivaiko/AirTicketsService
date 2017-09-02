namespace AirTicketsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Ticket_and_Seat_Models : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SeatModels", "SeatNumber", c => c.Int(nullable: false));
            AddColumn("dbo.SeatModels", "IsFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.TicketModels", "Name", c => c.String());
            AddColumn("dbo.TicketModels", "SurName", c => c.String());
            AddColumn("dbo.TicketModels", "PassportNumber", c => c.String());
            AddColumn("dbo.TicketModels", "PhoneNumber", c => c.String());
            AddColumn("dbo.TicketModels", "Email", c => c.String());
            DropColumn("dbo.TicketModels", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketModels", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.TicketModels", "Email");
            DropColumn("dbo.TicketModels", "PhoneNumber");
            DropColumn("dbo.TicketModels", "PassportNumber");
            DropColumn("dbo.TicketModels", "SurName");
            DropColumn("dbo.TicketModels", "Name");
            DropColumn("dbo.SeatModels", "IsFree");
            DropColumn("dbo.SeatModels", "SeatNumber");
        }
    }
}

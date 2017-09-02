namespace AirTicketsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Planes_Deleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FlightModels", "PlaneID");
            DropColumn("dbo.SeatModels", "PlaneID");
            DropColumn("dbo.TicketModels", "PlaneID");
            DropTable("dbo.PlaneModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlaneModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumOfSeats = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.TicketModels", "PlaneID", c => c.Int(nullable: false));
            AddColumn("dbo.SeatModels", "PlaneID", c => c.Int(nullable: false));
            AddColumn("dbo.FlightModels", "PlaneID", c => c.Int(nullable: false));
        }
    }
}

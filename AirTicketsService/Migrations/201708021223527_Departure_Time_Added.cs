namespace AirTicketsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Departure_Time_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlaneID = c.Int(nullable: false),
                        DeparturePlace = c.String(),
                        ArrivalPlace = c.String(),
                        Price = c.Double(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        DepartureTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlightModels");
        }
    }
}

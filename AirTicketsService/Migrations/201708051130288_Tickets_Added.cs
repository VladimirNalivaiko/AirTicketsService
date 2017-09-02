namespace AirTicketsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tickets_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlaneID = c.Int(nullable: false),
                        SeatID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TicketModels");
        }
    }
}

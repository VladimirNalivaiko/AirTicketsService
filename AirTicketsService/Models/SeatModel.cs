using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTicketsService.Models
{
    public class SeatModel
    {
        public int ID { get; set; }

        public int FlightID { get; set; }

        public int SeatNumber { get; set; }

        public bool isFree { get; set; }
    }
}
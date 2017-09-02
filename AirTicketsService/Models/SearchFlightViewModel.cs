using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTicketsService.Models
{
    public class SearchFlightViewModel
    {
        public List<FlightModel> DirectFlight { get; set; }

        public List<FlightModel> ReturnFlight { get; set; }
    }
}
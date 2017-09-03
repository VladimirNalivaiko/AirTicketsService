using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTicketsService.Models
{
    public class SearchFlightViewModel
    {
        public List<FlightViewModel> DirectFlight { get; set; }

        public List<FlightViewModel> ReturnFlight { get; set; }

        public string[] Mounth { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirTicketsService.Models
{
    public class FlightAdminViewModel
    {
        public int ID { get; set; }        

        public string DeparturePlace { get; set; }

        public string ArrivalPlace { get; set; }

        public double Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan DepartureTime { get; set; }

        public int NumOfFreeSeats { get; set; }

        public string ReturnUrl { get; set; }
    }
}
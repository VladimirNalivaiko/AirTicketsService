using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirTicketsService.Models
{
    public class TicketAdminViewModel
    {
        public int ID { get; set; }

        public string DeparturePlace { get; set; }

        public string ArrivalPlace { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan DepartureTime { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string PassportNumber { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int SeatNumber { get; set; }
    }
}
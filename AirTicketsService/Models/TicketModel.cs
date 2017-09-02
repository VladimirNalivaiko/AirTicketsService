using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirTicketsService.Models
{
    public class TicketModel
    {
        public int ID { get; set; }
        
        public int FlightID { get; set; }

        public int SeatID { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }
        
        public string PassportNumber { get; set; }
        
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
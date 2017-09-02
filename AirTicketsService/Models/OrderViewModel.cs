using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirTicketsService.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        
        public int FlightID { get; set; }

        public int SeatNumber { get; set; }

        public List<SelectListItem> FreeSeatList { get; set; }
        
        public string Name { get; set; }
        
        public string SurName { get; set; }

        public string PassportNumber { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}
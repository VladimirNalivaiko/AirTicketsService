using AirTicketsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTicketsService.Services
{
    public static class TicketService
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static List<TicketModel> GetTicketsList()
        {
            var list =  db.TicketModels.ToList();
            return list;
        }
    }
}
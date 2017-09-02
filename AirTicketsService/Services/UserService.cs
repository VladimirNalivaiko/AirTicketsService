using AirTicketsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTicketsService.Services
{
    public static class UserService
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static List<ApplicationUser> GetUsersList()
        {
            return db.Users.ToList();
        }
    }
}
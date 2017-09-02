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

        [Required(ErrorMessage = "Введите Ваше имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите Вашу фамилию")]
        [Display(Name = "Фамилию")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Введите номер Вашего пасспорта")]
        [Display(Name = "Номер пасспорта")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Введите номер Вашего телефона")]
        [Display(Name = "Мобильный номер")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите Ваш email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
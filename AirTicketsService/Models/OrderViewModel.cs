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

        public int DirectFlightID { get; set; }

        public int ReturnFlightID { get; set; }

        [Required(ErrorMessage = "Введите номер сиденья первого полета")]
        [Display(Name = "Номер сиденья")]
        public int DirectSeatNumber { get; set; }

        [Required(ErrorMessage = "Введите номер сиденья второго полета")]
        [Display(Name = "Номер сиденья")]
        public int ReturnSeatNumber { get; set; }

        public List<SelectListItem> DirectFreeSeatList { get; set; }

        public List<SelectListItem> ReturnFreeSeatList { get; set; }

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
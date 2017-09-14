using AirTicketsService.Services;
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

        public TicketModel() { }

        public TicketModel(OrderViewModel order, int flightID, int seatNumber)
        {
            this.FlightID = flightID;
            this.SeatID = SeatService.GetSeatByNumberAndFlightID(seatNumber, flightID).ID;
            this.Name = order.Name;
            this.SurName = order.SurName;
            this.PassportNumber = order.PassportNumber;
            this.PhoneNumber = order.PhoneNumber;
            this.Email = order.Email;
        }
    }
}
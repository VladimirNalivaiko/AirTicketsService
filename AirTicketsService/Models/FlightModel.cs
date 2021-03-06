﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirTicketsService.Models
{
    public class FlightModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите город назначения")]
        [Display(Name = "Город назначения")]
        public string DeparturePlace { get; set; }

        [Required(ErrorMessage = "Введите город вылета")]
        [Display(Name = "Город прибытия")]
        public string ArrivalPlace { get; set; }

        [Required(ErrorMessage = "Введите стоймость полета")]
        [Display(Name = "Стоймость")]
        public double Price { get; set; }
        
        [Required(ErrorMessage = "Введите дату вылета")]
        [Display(Name = "Дата прибытия")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        
        [Required(ErrorMessage = "Введите время полета")]
        [Display(Name = "Время полета")]
        [DataType(DataType.Time)]
        public TimeSpan TimeOfFlight { get; set; }

        [Required(ErrorMessage = "Введите количество мест"), 
            Range(1, 300, ErrorMessage = "Введенное значение должно быть 300 и больше 0")]
        [Display(Name = "Количество мест")]
        public int NumOfSeats { get; set; }   

        public FlightModel() { }

        public FlightModel(DoubleFlightViewModel flight, DateTime departureDate, TimeSpan departureTime,
                            TimeSpan timeOfFlight, double price, int numOfSeats)
        {
            this.ArrivalPlace = flight.ArrivalPlace;
            this.DeparturePlace = flight.DeparturePlace;
            this.DepartureDate = departureDate;
            this.DepartureDate = departureDate.AddHours(departureTime.Hours);
            this.DepartureDate = departureDate.AddMinutes(departureTime.Minutes);
            this.TimeOfFlight = timeOfFlight;
            this.Price = price;
            this.NumOfSeats = numOfSeats;
        }
    }
}
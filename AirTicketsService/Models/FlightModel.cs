using System;
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

        [Required(ErrorMessage = "Введите город прибытия")]
        [Display(Name = "Город прибытия")]
        public string ArrivalPlace { get; set; }

        [Required(ErrorMessage = "Введите стоймость полета")]
        [Display(Name = "Стоймость")]
        public double Price { get; set; }
        
        [Required(ErrorMessage = "Введите дату прибытия")]
        [Display(Name = "Дата прибытия")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Введите время прибытия")]
        [Display(Name = "Время прибытия")]
        [DataType(DataType.Time)]
        public TimeSpan DepartureTime { get; set; }

        [Required(ErrorMessage = "Введите время полета")]
        [Display(Name = "Время полета")]
        [DataType(DataType.Time)]
        public TimeSpan FlightTime { get; set; }

        [Required(ErrorMessage = "Введите количество мест")]
        [Display(Name = "Количество мест")]
        public int NumOfSeats { get; set; }   
    }

}
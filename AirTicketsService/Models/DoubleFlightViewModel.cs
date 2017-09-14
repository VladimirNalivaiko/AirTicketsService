using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirTicketsService.Models
{
    public class DoubleFlightViewModel
    {
        [Required(ErrorMessage = "Введите город назначения")]
        [Display(Name = "Город назначения")]
        public string DeparturePlace { get; set; }

        [Required(ErrorMessage = "Введите город прибытия")]
        [Display(Name = "Город прибытия")]
        public string ArrivalPlace { get; set; }

        [Required(ErrorMessage = "Введите стоймость полета")]
        [Display(Name = "Стоймость")]
        public double DirectPrice { get; set; }

        [Required(ErrorMessage = "Введите стоймость полета")]
        [Display(Name = "Стоймость")]
        public double ReturnPrice { get; set; }

        [Required(ErrorMessage = "Введите дату вылета туда")]
        [Display(Name = "Дата вылета туда")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DirectDepartureDate { get; set; }

        [Required(ErrorMessage = "Введите дату вылета обратно")]
        [Display(Name = "Дата вылета обратно")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReturnDepartureDate { get; set; }

        [Required(ErrorMessage = "Введите время вылета туда")]
        [Display(Name = "Время вылета туда")]
        [DataType(DataType.Time)]
        public TimeSpan DirectDepartureTime { get; set; }

        [Required(ErrorMessage = "Введите время вылета обратно")]
        [Display(Name = "Время вылета обратно")]
        [DataType(DataType.Time)]
        public TimeSpan ReturnDepartureTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime DirectArrivalDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnArrivalDate { get; set; }

        public string DirectDepartureDateInfo { get; set; }

        public string DirectArrivalDateInfo { get; set; }

        public string ReturnDepartureDateInfo { get; set; }

        public string ReturnArrivalDateInfo { get; set; }

        [Required(ErrorMessage = "Введите время полета туда")]
        [Display(Name = "Время полета туда")]
        [DataType(DataType.Time)]
        public TimeSpan DirectTimeOfFlight { get; set; }

        [Required(ErrorMessage = "Введите время полета обратно")]
        [Display(Name = "Время полета обратно")]
        [DataType(DataType.Time)]
        public TimeSpan ReturnTimeOfFlight { get; set; }

        [Required(ErrorMessage = "Введите количество мест туда"),
            Range(1, 300, ErrorMessage = "Введенное значение должно быть 300 и больше 0")]
        [Display(Name = "Количество мест туда")]
        public int DirectNumOfSeats { get; set; }

        [Required(ErrorMessage = "Введите количество мест обратно"),
            Range(1, 300, ErrorMessage = "Введенное значение должно быть 300 и больше 0")]
        [Display(Name = "Количество мест обратно")]
        public int ReturnNumOfSeats { get; set; }

        public string ReturnUrl { get; set; }
    }
}
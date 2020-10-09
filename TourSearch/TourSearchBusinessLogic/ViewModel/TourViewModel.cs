using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourSearchBusinessLogic.ViewModel
{
   public class TourViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тур Оператор")]
        public string TourOperatorName { get; set; }
        [DisplayName("Дата вылета")]
        public DateTime StartDate { get; set; }
        [DisplayName("Дата прилёта")]
        public DateTime EndDate { get; set; }
        [DisplayName("Город вылета")]
        public string DepartureName { get; set; }
        [DisplayName("Страна")]
        public string CountryName { get; set; }      
        [DisplayName("Курорт")]
        public string ResortName { get; set; }
        [DisplayName("Отель")]
        public string HotelName { get; set; }
        [DisplayName("Количество звёзд")]
        public string StarName { get; set; }
        [DisplayName("Тип питания")]
        public string MealName { get; set; }
        [DisplayName("Тип номера")]
        public string RoomName { get; set; }
        [DisplayName("Кол-во мест")]
        public int CountPlaces { get; set; }
        [DisplayName("Цена")]
        public decimal Cost { get; set; }
    }
}

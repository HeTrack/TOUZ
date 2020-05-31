using System;
using System.Collections.Generic;
using System.Text;

namespace TourBusinessLogic.ViewModel
{
    public class Tour
    {
        public Guid Id { get; set; }
        public string TourOperator { get; set; }
        public Hotel Hotel { get;set; }
        public string Room { get; set; }
        /// <summary>
        /// Город вылета
        /// </summary>
        public City DepartureCity { get;  set; }
        /// <summary>
        /// Дата вылета
        /// </summary>
        public DateTime FromDate { get; private set; }
        /// <summary>
        /// Дата прилета обратно
        /// </summary>
        public DateTime ToDate { get; private set; }
        /// <summary>
        /// Дата заезда
        /// </summary>
        public DateTime CheckInHotel { get; private set; }
        /// <summary>
        /// Количество ночей
        /// </summary>
        public int Days { get; private set; }
        /// <summary>
        /// Цена за одного человека
        /// </summary>
        public decimal PriceByOnePeople { get; private set; }
        /// <summary>
        /// Полная цена за всех людей в туре
        /// </summary>
        public decimal? FullPrice { get; private set; }
        public string Airline { get; private set; }
        public int MaxRoomPeopleCount { get; private set; }
    }
}


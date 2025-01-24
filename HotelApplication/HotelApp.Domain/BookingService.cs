using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain
{
    /// <summary>
    /// Класс для работы с услугами конкретного бронирования
    /// </summary>
    public record BookingService
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public long BookingServiceId { get; set; } 
        /// <summary>
        /// Внешний ключ на бронирование
        /// </summary>
        public long BookingId { get; set; } 
        /// <summary>
        /// Внешний ключ на услугу
        /// </summary>
        public long ServiceId { get; set; } 
        /// <summary>
        /// Количество услуг
        /// </summary>
        public int Quantity { get; set; } 
    }
}

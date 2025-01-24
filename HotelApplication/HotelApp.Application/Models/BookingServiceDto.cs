using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Models
{
    /// <summary>
    /// Сокращённая информация о сервисах для бронирования
    /// </summary>
    public record BookingServiceDto
    {
        /// <summary>
        /// Идентификатор.
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
        ///  Количество услуг
        /// </summary>
        public int Quantity { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain
{
    /// <summary>
    /// Класс для работы с бронированиями
    /// </summary>
    public record Booking
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public long BookingId { get; set; } 
        /// <summary>
        /// Внешний ключ на клиента
        /// </summary>
        public int ClientId { get; set; } 
        /// <summary>
        /// Внешний ключ на номер
        /// </summary>
        public int RoomId { get; set; } 
        /// <summary>
        /// Дата заезда
        /// </summary>
        public DateTime CheckInDate { get; set; } 
        /// <summary>
        /// Дата выезда
        /// </summary>
        public DateTime CheckOutDate { get; set; } 
        /// <summary>
        /// Общая стоимость
        /// </summary>
        public decimal TotalPrice { get; set; } 
    }
}

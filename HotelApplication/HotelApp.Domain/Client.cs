using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain

/// <summary>
/// Класс для работы с клиентами.
/// </summary>
{
    public record Client
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long ClientId { get; set; }
        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Телефон.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Почта.
        /// </summary>
        public string Email { get; set; } // Почта

        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public ICollection<Booking>? Bookings { get; set; }
    }
}
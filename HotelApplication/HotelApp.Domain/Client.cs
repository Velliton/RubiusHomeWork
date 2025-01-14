using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain

/// <summary>
/// Клиент.
/// </summary>
{
    public record Client
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long ClientId { get; set; }
        /// <summary>
        /// FullName.
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Phone.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; } // Почта


        public ICollection<Booking>? Bookings { get; set; }
    }
}
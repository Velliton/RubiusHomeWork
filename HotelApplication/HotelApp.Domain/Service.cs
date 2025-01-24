using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain
{
    /// <summary>
    /// Класс для работы с услугами отеля
    /// </summary>
    public record Service
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public long ServiceId { get; set; }
        /// <summary>
        /// Название услуги
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Стоимость услуги
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the booking services. Navigation propertie.
        /// </summary>
        /// <value>
        /// The booking services.
        /// </value>
        public ICollection<BookingService> BookingServices { get; set; }
    }
}

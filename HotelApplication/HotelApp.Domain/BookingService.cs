using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain
{
    public record BookingService
    {
        public long BookingServiceId { get; set; } // Первичный ключ
        public long BookingId { get; set; } // Внешний ключ на бронирование
        public long ServiceId { get; set; } // Внешний ключ на услугу
        public int Quantity { get; set; } // Количество услуг
    }
}

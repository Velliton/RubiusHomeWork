using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain
{
    public record Service
    {
        public long ServiceId { get; set; } // Первичный ключ
        public string ServiceName { get; set; } // Название услуги
        public decimal Price { get; set; } // Стоимость услуги

        // Навигационное свойство
        public ICollection<BookingService> BookingServices { get; set; }
    }
}

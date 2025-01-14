using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain
{
    public record Category
    {
        public long CategoryId { get; set; } // Первичный ключ
        public string CategoryName { get; set; } // Название категории
        public decimal PricePerNight { get; set; } // Стоимость за ночь

        // Навигационное свойство
        public ICollection<Room> Rooms { get; set; }
    }
}

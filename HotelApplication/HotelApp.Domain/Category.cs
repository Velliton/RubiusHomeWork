using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain
{
    /// <summary>
    /// Класс для работы с категориями номеров
    /// </summary>
    public record Category
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public long CategoryId { get; set; } 
        /// <summary>
        /// Название категории
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Стоимость за ночь
        /// </summary>
        public decimal PricePerNight { get; set; }
        /// <summary>
        /// Навигационное свойство
        /// </summary>
        public ICollection<Room> Rooms { get; set; }
    }
}

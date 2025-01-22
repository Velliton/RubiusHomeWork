using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Models
{
    /// <summary>
    /// Сокращённая информация о категориях номеров
    /// </summary>
    public record CategoryDto
    {
        /// <summary>
        ///  Первичный ключ
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Models
{
    public record CategoryDto
    {
        public long CategoryId { get; set; } // Первичный ключ
        public string CategoryName { get; set; } // Название категории
        public decimal PricePerNight { get; set; } // Стоимость за ночь
    }
}

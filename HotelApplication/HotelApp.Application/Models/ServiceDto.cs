using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Models
{
    public record ServiceDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long ServiceId { get; set; } // Первичный ключ
        public string ServiceName { get; set; } // Название услуги
        public decimal Price { get; set; } // Стоимость услуги
    }
}

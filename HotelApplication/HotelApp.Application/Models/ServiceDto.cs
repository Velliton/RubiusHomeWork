using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Models
{
    /// <summary>
    /// Краткая информация об услугах
    /// </summary>
    public record ServiceDto
    {
        /// <summary>
        /// Идентификатор.
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
    }
}

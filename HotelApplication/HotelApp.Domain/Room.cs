using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Domain
{
    /// <summary>
    /// Комната
    /// </summary>
    public record Room
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long RoomId { get; set; }
        /// <summary>
        /// Номер комнаты.
        /// </summary>
        public int RoomNumber { get; set; }
        /// <summary>
        /// Внешний ключ на категорию.
        /// </summary>
        public long CategoryId { get; set; }
        /// <summary>
        /// Описание.  
        /// </summary>
        public string Description { get; set; }
    }
}

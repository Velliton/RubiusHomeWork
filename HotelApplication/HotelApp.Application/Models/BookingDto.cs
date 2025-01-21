using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Models
{
    public record BookingDto
    {
        public long BookingId { get; set; } // Первичный ключ
        public int ClientId { get; set; } // Внешний ключ на клиента
        public int RoomId { get; set; } // Внешний ключ на номер
        public DateTime CheckInDate { get; set; } // Дата заезда
        public DateTime CheckOutDate { get; set; } // Дата выезда
        public decimal TotalPrice { get; set; } // Общая стоимость
    }
}

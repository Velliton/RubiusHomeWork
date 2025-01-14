using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Models
{
    public record ClientDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long ClientId { get; set; }
        /// <summary>
        /// FullName.
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Phone.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; } // Почта
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        public NotFoundException() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NotFoundException(string message) : base(message) { }
    }
}

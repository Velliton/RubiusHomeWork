using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Abstractions.Repositories
{
    public interface IBookingServRepository
    {
        Task<IReadOnlyCollection<BookingService>> GetBookingServices();

        Task<BookingService> GetById(long id);

        Task<long> Create(BookingService bookingServ);
        Task Delete(long id);

        Task Update(BookingService bookingService);
    }
}

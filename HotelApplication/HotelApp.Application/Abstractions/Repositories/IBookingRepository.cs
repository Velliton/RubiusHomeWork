using HotelApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Application.Abstractions.Repositories
{
    public interface IBookingRepository
    {
        Task<IReadOnlyCollection<Booking>> GetBookings();

        Task<Booking> GetById(long id);

        Task<long> Create(Booking booking);
        Task Delete(long id);

        Task Update(Booking booking);
    }
}

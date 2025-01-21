using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Application.Services;
using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Abstractions.Repositories;
using HotelApp.Domain;
using HotelApp.Application.Services;
using HotelApp.Application.Models;
using AutoMapper;

namespace HotelApp.Application.Services
{
    public class BookingService(IBookingRepository bookingRepository, IMapper mapper) : IBookingService
    {
        public Task<long> Create(BookingDto booking)
        {
            var entity = mapper.Map<Booking>(booking); 
            return bookingRepository.Create(entity);
        }

        public Task Delete(long id)
        {
            return bookingRepository.Delete(id);
        }

        public async Task<BookingDto> GetById(long id)
        {
            var result = await bookingRepository.GetById(id);
            return mapper.Map<BookingDto>(result); 
        }

        public async Task<IReadOnlyCollection<BookingDto>> GetBookings()
        {
            var result = await bookingRepository.GetBookings();
            return mapper.Map<IReadOnlyCollection<BookingDto>>(result);
        }

        public async Task Update(BookingDto booking)
        {
            var entity = mapper.Map<Booking>(booking);
            await bookingRepository.Update(entity);
            return;
        }


    }
}

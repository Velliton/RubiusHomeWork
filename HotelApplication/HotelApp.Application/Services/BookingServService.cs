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
    public class BookingServService(IBookingServRepository bookingServRepository, IMapper mapper) : IBookingServService
    {
        public Task<long> Create(BookingServiceDto bookingServ)
        {
            var entity = mapper.Map<Domain.BookingService>(bookingServ); 
            return bookingServRepository.Create(entity);
        }

        public Task Delete(long id)
        {
            return bookingServRepository.Delete(id);
        }

        public async Task<BookingServiceDto> GetById(long id)
        {
            var result = await bookingServRepository.GetById(id);
            return mapper.Map<BookingServiceDto>(result); 
        }

        public async Task<IReadOnlyCollection<BookingServiceDto>> GetBookingServices()
        {
            var result = await bookingServRepository.GetBookingServices();
            return mapper.Map<IReadOnlyCollection<BookingServiceDto>>(result);
        }

        public async Task Update(BookingServiceDto bookingServ)
        {
            var entity = mapper.Map<Domain.BookingService>(bookingServ);
            await bookingServRepository.Update(entity);
            return;
        }
    }
}

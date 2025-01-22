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
    /// <summary>
    /// Экземпляр сервиса для работы с услугами бронирования
    /// </summary>
    /// <param name="bookingServRepository">Репозиторий для управления сущностями</param>
    /// <param name="mapper">Объект маппера для преобразования между моделями и DTO</param>
    public class BookingServService(IBookingServRepository bookingServRepository, IMapper mapper) : IBookingServService
    {
        /// <summary>
        /// Добавляет новую услугу в бронирование
        /// </summary>
        /// <param name="bookingServ"></param>
        /// <returns></returns>
        public Task<long> Create(BookingServiceDto bookingServ)
        {
            var entity = mapper.Map<Domain.BookingService>(bookingServ); 
            return bookingServRepository.Create(entity);
        }
        /// <summary>
        /// Удаляет услугу из бронирования
        /// </summary>
        /// <param name="id">Идентификатор услуги бронирования для удаления</param>
        /// <returns>Асинхронная операция</returns>
        public Task Delete(long id)
        {
            return bookingServRepository.Delete(id);
        }
        /// <summary>
        /// Получения услуги бронирования по Id
        /// </summary>
        /// <param name="id">Идентификатор услуги бронирования</param>
        /// <returns>DTO объекта услуги бронирования, соответствующего указанному идентификатору.</returns>
        public async Task<BookingServiceDto> GetById(long id)
        {
            var result = await bookingServRepository.GetById(id);
            return mapper.Map<BookingServiceDto>(result); 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<BookingServiceDto>> GetBookingServices()
        {
            var result = await bookingServRepository.GetBookingServices();
            return mapper.Map<IReadOnlyCollection<BookingServiceDto>>(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookingServ"></param>
        /// <returns></returns>
        public async Task Update(BookingServiceDto bookingServ)
        {
            var entity = mapper.Map<Domain.BookingService>(bookingServ);
            await bookingServRepository.Update(entity);
            return;
        }
    }
}

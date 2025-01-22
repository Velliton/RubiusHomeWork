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
    /// Экземпляр сервиса для работы с бронированием
    /// </summary>
    /// <param name="bookingRepository">Репозиторий для управления сущностями бронирования.</param>
    /// <param name="mapper">Объект маппера для преобразования между моделями и DTO</param>
    public class BookingService(IBookingRepository bookingRepository, IMapper mapper) : IBookingService
    {
        /// <summary>
        /// Создаёт новое бронирование
        /// </summary>
        /// <param name="booking">dtoс информацией о бронировании</param>
        /// <returns>Идентификатор созданного бронирования</returns>
        public async Task<long> Create(BookingDto booking)
        {
            var entity = mapper.Map<Booking>(booking);

            if (!await IsRoomAvailableAsync(entity.RoomId, entity.CheckInDate, entity.CheckOutDate))
            {
                throw new InvalidOperationException("The selected room is not available for the selected dates.");
            }

            return await bookingRepository.Create(entity);
        }
        /// <summary>
        /// Удаляет бронирование
        /// </summary>
        /// <param name="id">Идентификатор бронирования для удаления</param>
        /// <returns>Асинхронная операция</returns>
        public Task Delete(long id)
        {
            return bookingRepository.Delete(id);
        }
        /// <summary>
        /// Возвращает данные о бронировании по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор бронирования.</param>
        /// <returns>
        /// DTO объекта бронирования, соответствующего указанному идентификатору.
        /// </returns>
        public async Task<BookingDto> GetById(long id)
        {
            var result = await bookingRepository.GetById(id);
            return mapper.Map<BookingDto>(result); 
        }
        /// <summary>
        /// Возвращает список всех бронирований.
        /// </summary>
        /// <returns>
        /// Коллекция DTO объектов бронирований.
        /// </returns>
        public async Task<IReadOnlyCollection<BookingDto>> GetBookings()
        {
            var result = await bookingRepository.GetBookings();
            return mapper.Map<IReadOnlyCollection<BookingDto>>(result);
        }
        /// <summary>
        /// Обновляет данные бронирования.
        /// </summary>
        /// <param name="booking">DTO с обновлённой информацией о бронировании.</param>
        /// <returns>
        /// Асинхронная операция.
        /// </returns>
        public async Task Update(BookingDto booking)
        {
            var entity = mapper.Map<Booking>(booking);
            await bookingRepository.Update(entity);
            return;
        }

        public async Task<bool> IsRoomAvailableAsync(int roomId, DateTime startDate, DateTime endDate)
        {
            // Получаем все бронирования для указанной комнаты
            var bookings = await bookingRepository.GetBookingsByRoomIdAsync(roomId);

            // Проверяем пересечения дат
            return !bookings.Any(b => b.CheckInDate < endDate && b.CheckOutDate > startDate);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelApp.Domain;
using HotelApp.Application.Models;

namespace HotelApp.Application.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ApplicationMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMappingProfile"/> class.
        /// </summary>
        public ApplicationMappingProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<Booking, BookingDto>();
            CreateMap<BookingDto, Booking>();

            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceDto, Service>();

            CreateMap<BookingService, BookingServiceDto>();
            CreateMap<BookingServiceDto, BookingService>();
        } 

    }
}

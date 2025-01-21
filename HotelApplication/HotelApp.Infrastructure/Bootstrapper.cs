using HotelApp.Application.Abstractions.Repositories;
using HotelApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApp.Infrastructure
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var connectionString = "Host=localhost;Database=hotelDb;Username=postgres;Password=1qaz!QAZ";
            services.AddDbContext<MyDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IBookingServRepository, BookingServRepository>();

            return services;
        }
    }
}

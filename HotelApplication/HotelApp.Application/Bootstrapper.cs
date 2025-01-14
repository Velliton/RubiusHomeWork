using HotelApp.Application.Abstractions.Services;
using HotelApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using HotelApp.Application.Abstractions.Repositories;
using HotelApp.Application.Mapping;

namespace HotelApp.Application
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof (ApplicationMappingProfile));
            services.AddScoped<IClientService, ClientService>();

            return services;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApp.Infrastructure.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class MigrationExtensions
    {
        /// <summary>
        /// Applies the migrations.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void ApplyMigrations(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();

            //
            context.Database.Migrate();
        }
    }
}

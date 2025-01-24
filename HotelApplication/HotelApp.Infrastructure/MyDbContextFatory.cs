using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace HotelApp.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory&lt;HotelApp.Infrastructure.MyDbContext&gt;" />
    public class MyDbContextFatory : IDesignTimeDbContextFactory<MyDbContext>
    {
        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>
        /// An instance of <typeparamref name="TContext" />.
        /// </returns>
        public MyDbContext CreateDbContext(string[] args) 
        {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=hotelDb;Username=postgres;Password=1qaz!QAZ");
            return new MyDbContext(optionsBuilder.Options);
        }
    }
}



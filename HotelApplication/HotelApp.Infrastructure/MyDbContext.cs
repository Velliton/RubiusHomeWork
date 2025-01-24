using Microsoft.EntityFrameworkCore;
using HotelApp.Domain;

namespace HotelApp.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class MyDbContext: DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { 
        
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }

    }
}
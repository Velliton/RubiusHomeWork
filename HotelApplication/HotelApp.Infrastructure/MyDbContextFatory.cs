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
    public class MyDbContextFatory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args) 
        {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=hotelDb;Username=postgres;Password=1qaz!QAZ");
            return new MyDbContext(optionsBuilder.Options);
        }
    }
}



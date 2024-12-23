using BooksApp;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
      
        using var context = new AppDbContext();
        context.Database.Migrate();
    
    }
}
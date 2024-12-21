using CarsApp;
using System;

namespace CarsApp
{
    public class Program
    {
        public static void Main()
        {
            using var context = new AppDbContext();

            try
            {
                if (context.Database.CanConnect())
                {
                    Console.WriteLine("Successfully connected to the database.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
                return;
            }

            _ = context.Database.EnsureCreated();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. View all cars");
                Console.WriteLine("2. Find car by ID");
                Console.WriteLine("3. Add car");
                Console.WriteLine("4. Edit car");
                Console.WriteLine("5. Delete car");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CrudOperations.ViewAll(context);
                        break;
                    case 2:
                        CrudOperations.FindById(context);
                        break;
                    case 3:
                        CrudOperations.AddCar(context);
                        break;
                    case 4:
                        CrudOperations.EditCar(context);
                        break;
                    case 5:
                        CrudOperations.DeleteCar(context);
                        break;
                    case 6:
                        return;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public static class CrudOperations
    {
        public static void ViewAll(AppDbContext context)
        {
            Console.Clear();
            var cars = context.Cars.ToList();
            Console.WriteLine("Cars:");
            foreach (var car in cars)
            {
                Console.WriteLine($"ID: {car.Id}, Model: {car.Model}, Year: {car.Year}");
            }
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }

        public static void FindById(AppDbContext context)
        {
            Console.Clear();
            Console.Write("Enter ID to search: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var car = context.Cars.Find(id);
                if (car != null)
                {
                    Console.WriteLine($"ID: {car.Id}, Model: {car.Model}, Year: {car.Year}");
                }
                else
                {
                    Console.WriteLine("Car not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }

        public static void AddCar(AppDbContext context)
        {
            Console.Clear();
            Console.Write("Enter model: ");
            var model = Console.ReadLine();
            Console.Write("Enter year: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                var newCar = new Car { Model = model, Year = year };
                context.Cars.Add(newCar);
                context.SaveChanges();
                Console.WriteLine("Car added successfully. Press Enter to return to menu.");
            }
            else
            {
                Console.WriteLine("Invalid year. Press Enter to try again.");
            }
            Console.ReadLine();
        }

        public static void EditCar(AppDbContext context)
        {
            Console.Clear();
            Console.Write("Enter ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var car = context.Cars.Find(id);
                if (car != null)
                {
                    Console.Write("Enter new model: ");
                    car.Model = Console.ReadLine();
                    Console.Write("Enter new year: ");
                    if (int.TryParse(Console.ReadLine(), out int year))
                    {
                        car.Year = year;
                        context.SaveChanges();
                        Console.WriteLine("Car updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid year.");
                    }
                }
                else
                {
                    Console.WriteLine("Car not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }

        public static void DeleteCar(AppDbContext context)
        {
            Console.Clear();
            Console.Write("Enter ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var car = context.Cars.Find(id);
                if (car != null)
                {
                    context.Cars.Remove(car);
                    context.SaveChanges();
                    Console.WriteLine("Car deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Car not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }
    }

}

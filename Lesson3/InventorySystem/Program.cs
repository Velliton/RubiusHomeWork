using System;
using System.Collections.Generic;

namespace InventorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> inventory = new Dictionary<string, int>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nМЕНЮ:");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Просмотреть все товары");
                Console.WriteLine("3. Удалить товар");
                Console.WriteLine("4. Найти товар");
                Console.WriteLine("5. Выйти");
                Console.Write("Введите номер действия: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItem(inventory);
                        break;
                    case "2":
                        ViewAllItems(inventory);
                        break;
                    case "3":
                        RemoveItem(inventory);
                        break;
                    case "4":
                        SearchItem(inventory);
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }

        static void AddItem(Dictionary<string, int> inventory)
        {
            Console.Write("Введите название товара: ");
            string name = Console.ReadLine();
            Console.Write("Введите количество: ");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                if (inventory.ContainsKey(name))
                {
                    inventory[name] += quantity;
                    Console.WriteLine($"Количество товара '{name}' обновлено. Новое количество: {inventory[name]}.");
                }
                else
                {
                    inventory[name] = quantity;
                    Console.WriteLine($"Товар '{name}' добавлен с количеством: {quantity}.");
                }
            }
            else
            {
                Console.WriteLine("Некорректное количество. Введите целое число.");
            }
        }

        static void ViewAllItems(Dictionary<string, int> inventory)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Склад пуст.");
            }
            else
            {
                Console.WriteLine("Список всех товаров:");
                foreach (var item in inventory)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }

        static void RemoveItem(Dictionary<string, int> inventory)
        {
            Console.Write("Введите название товара для удаления: ");
            string name = Console.ReadLine();

            if (inventory.ContainsKey(name))
            {
                inventory.Remove(name);
                Console.WriteLine($"Товар '{name}' удален.");
            }
            else
            {
                Console.WriteLine($"Товар '{name}' не найден.");
            }
        }

        static void SearchItem(Dictionary<string, int> inventory)
        {
            Console.Write("Введите название товара для поиска: ");
            string name = Console.ReadLine();

            if (inventory.TryGetValue(name, out int quantity))
            {
                Console.WriteLine($"{name}: {quantity}");
            }
            else
            {
                Console.WriteLine($"Товар '{name}' не найден.");
            }
        }
    }
}
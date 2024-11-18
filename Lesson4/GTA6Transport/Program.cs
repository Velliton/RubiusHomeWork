using System;
using System.Collections.Generic;

namespace GTA6TransportSelection
{
    abstract class Transport
    {
        public string TypeName { get; protected set; }
        public abstract List<string> Subtypes { get; }

        public Transport(string typeName)
        {
            TypeName = typeName;
        }

        public virtual void DisplayType()
        {
            Console.WriteLine($"Вы выбрали: {TypeName} транспорт.");
        }

        public abstract void DisplaySubtype(int subtypeIndex);

        ~Transport()
        {
            Console.WriteLine($"Освобождаем ресурсы для типа: {TypeName}");
        }
    }

    class WaterTransport : Transport
    {
        public override List<string> Subtypes => new List<string> { "Лодка", "Яхта", "Субмарина" };

        public WaterTransport() : base("Водный") { }

        public override void DisplaySubtype(int subtypeIndex)
        {
            Console.WriteLine($"Отличный выбор! Вы передвигаетесь на: {Subtypes[subtypeIndex]}, тип транспорта: {TypeName}.");
        }
    }

    class AirTransport : Transport
    {
        public override List<string> Subtypes => new List<string> { "Вертолет", "Самолет", "Дирижабль" };

        public AirTransport() : base("Воздушный") { }

        public override void DisplaySubtype(int subtypeIndex)
        {
            Console.WriteLine($"Отличный выбор! Вы передвигаетесь на: {Subtypes[subtypeIndex]}, тип транспорта: {TypeName}.");
        }
    }

    class LandTransport : Transport
    {
        public override List<string> Subtypes => new List<string> { "Мотоцикл", "Автомобиль", "Поезд" };

        public LandTransport() : base("Наземный") { }

        public override void DisplaySubtype(int subtypeIndex)
        {
            Console.WriteLine($"Отличный выбор! Вы передвигаетесь на: {Subtypes[subtypeIndex]}, тип транспорта: {TypeName}.");
        }
    }

    class Program
    {
        static void Main()
        {
            List<Transport> transports = new List<Transport>
            {
                new WaterTransport(),
                new AirTransport(),
                new LandTransport()
            };

            Console.WriteLine("Выберите тип транспорта:");
            for (int i = 0; i < transports.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {transports[i].TypeName}");
            }

            Console.Write("Введите номер типа транспорта (1-3): ");
            int typeChoice = int.Parse(Console.ReadLine()) - 1;

            if (typeChoice < 0 || typeChoice >= transports.Count)
            {
                Console.WriteLine("Некорректный выбор типа транспорта.");
                return;
            }

            Transport chosenTransport = transports[typeChoice];
            chosenTransport.DisplayType();

            Console.WriteLine($"Доступные подтипы {chosenTransport.TypeName.ToLower()} транспорта:");
            for (int i = 0; i < chosenTransport.Subtypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {chosenTransport.Subtypes[i]}");
            }

            Console.Write("Введите номер подтипа транспорта (1-3): ");
            int subtypeChoice = int.Parse(Console.ReadLine()) - 1;

            if (subtypeChoice < 0 || subtypeChoice >= chosenTransport.Subtypes.Count)
            {
                Console.WriteLine("Некорректный выбор подтипа транспорта.");
                return;
            }

            chosenTransport.DisplaySubtype(subtypeChoice);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ZAGS.Models;

namespace ZAGS.Services
{
    public class RegistryService
    {
        private readonly List<RegistrationRecord> _records = new();

        public void AddRecord(string surname, DateTime registrationDate)
        {
            _records.Add(new RegistrationRecord
            {
                Surname = surname,
                RegistrationDate = registrationDate
            });
            Console.WriteLine("Запись успешно добавлена!");
        }

        public IEnumerable<RegistrationRecord> GetAllRecordsSorted()
        {
            return _records.OrderBy(record => record.RegistrationDate);
        }

        public IEnumerable<RegistrationRecord> GetRecordsByDate(DateTime date)
        {
            return _records.Where(record => record.RegistrationDate.Date == date.Date);
        }
    }
}
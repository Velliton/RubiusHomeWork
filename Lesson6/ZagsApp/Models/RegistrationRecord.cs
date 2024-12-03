using System;

namespace ZAGS.Models
{
    public class RegistrationRecord
    {
        public string Surname { get; set; }
        public DateTime RegistrationDate { get; set; }

        public override string ToString()
        {
            return $"{RegistrationDate:yyyy-MM-dd}: {Surname}";
        }
    }
}
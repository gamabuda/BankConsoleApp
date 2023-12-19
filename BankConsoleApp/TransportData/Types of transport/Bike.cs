using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.TransportData.Types_of_transport
{
    public class Bike : ITransport
    {
        public int Speed { get; set; }
        public string Motor { get; set; }
        public string Color { get; set; }
        public string CategoryofRights { get; set; }
        public string Model { get; set; }
        public bool IsArended { get; set; }
        public int Wheels { get; set; }

        public decimal RentalCost { get; } = 70; // Пример стоимости аренды для мотоцикла

        public void Rent()
        {
            if (!IsArended)
            {
                Console.WriteLine("Мотоцикл успешно арендован!");
                IsArended = true;
            }
            else
            {
                Console.WriteLine("Мотоцикл уже арендован!");
            }
        }

        public void Return()
        {
            if (IsArended)
            {
                Console.WriteLine("Мотоцикл успешно возвращен!");
                IsArended = false;
            }
            else
            {
                Console.WriteLine("Мотоцикл не арендован, нечего возвращать!");
            }
        }
    }
}

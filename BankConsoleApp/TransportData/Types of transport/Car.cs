using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.TransportData.Types_of_transport
{
    public class Car : ITransport
    {
        public int Speed { get; set; }
        public string Motor { get; set; }
        public string Color { get; set; }
        public string CategoryofRights { get; set; }
        public string Model { get; set; }
        public bool IsArended { get; set; }
        public int Wheels { get; set; }

        public decimal RentalCost { get; } = 100; // Пример стоимости аренды для автомобиля


        public void Rent()
        {
            if (!IsArended)
            {
                Console.WriteLine("Автомобиль успешно арендован!");
                IsArended = true;
            }
            else
            {
                Console.WriteLine("Автомобиль уже арендован!");
            }
        }

        public void Return()
        {
            if (IsArended)
            {
                Console.WriteLine("Автомобиль успешно возвращен!");
                IsArended = false;
            }
            else
            {
                Console.WriteLine("Автомобиль не арендован, нечего возвращать!");
            }
        }
    }

}

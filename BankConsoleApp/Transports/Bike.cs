using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data.Transports
{
    class Bike : Transport
    {
        public event TransportInfo? Information;
        public string Motor { get; set; }
        public float Speed { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string RightsCategory { get; set; }
        public bool Rent { get; set; }
        public int NumWheels { get; set; }
        public decimal Price { get; }

        //Конструктор класса
        public Bike(float speed, string color, string model, string motor, bool rent, int numWheels, decimal price)
        {
            Speed = speed;
            Color = color;
            Model = model;
            Motor = motor;
            Rent = rent;
            NumWheels = numWheels;
            Price = price;
        }
        public void PrintInfo(string msg)
        {
            Console.WriteLine($"Bicycle - Model: {Model}, RightsCategory: {RightsCategory} Color: {Color}, Speed: {Speed}, Rent: {Rent}, NumWheels: {NumWheels}");
        }
    }
}

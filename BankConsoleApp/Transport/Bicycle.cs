using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    public class Bicycle : Transport
    {
        public event TransportInfo? Information;
        public string Model { get; set; }
        public string Color { get; set; }
        public int MaxSpeed { get; set; }
        public int Category { get; set; }
        public bool IsRented { get; set; }
        public int WheelCount { get; set; }
        public int HasMotor { get; set; }
        public string AdditionalFeature { get; set; }
        public decimal Price { get; }

        public Bicycle(string model, string color, int maxspeed, int category, bool isrented, int whellcount, int hasmotor, decimal price)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxspeed;
            Category = category;
            IsRented = isrented;
            WheelCount = whellcount;
            HasMotor = hasmotor;
            Price = price;
        }

        public void Info (string msg)
        {
            Console.WriteLine($"Велосипед - {Model}, цвет: {Color}, макс скорость: {MaxSpeed}, категория: {Category}, бронь: {IsRented}, кол-во колес: {WheelCount}, мотор: {HasMotor}");
        }
    }
}



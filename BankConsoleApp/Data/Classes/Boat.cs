using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data.Classes
{
    public class Boat : Transport
    {
        public event TransportInfo? Information;
        public string Model { get; set; }
        public string Color { get; set; }
        public int MaxSpeed { get; set; }
        public bool IsRented { get; set; }
        public string Motor { get; set; }
        public decimal Price { get; }
        public string AdditionalFeature { get; set; }

        public Boat(string model, string color, int maxspeed, bool isrented, string motor, decimal price, string additionalfeature)
        {
            Model = model;
            Color = color;
            MaxSpeed = maxspeed;
            IsRented = isrented;
            Motor = motor;
            Price = price;
            AdditionalFeature = additionalfeature;
        }
        public void PrintInfo(string msg)
        {
            Console.WriteLine($"Boat - Model: {Model}, Color: {Color}, Max Speed: {MaxSpeed}, Is Rented: {IsRented},  Motor: {Motor}, Additional Feature: {AdditionalFeature}");
        }
    }
}

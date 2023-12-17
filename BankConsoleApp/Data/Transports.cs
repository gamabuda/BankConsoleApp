using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal abstract class Transport : IRentable
    {
        public abstract void Move();

        private string _model;
        public string Model
        {
            get => _model;
            set { _model = value; }
        }
        private string _color;
        public string Color
        {
            get => _color;
            set { _color = value; }
        }
        private int _speed;
        public int Speed
        {
            get => _speed;
            set { _speed = value; }
        }
        private int _wheels;
        public int Wheels
        {
            get => _wheels;
            set { _wheels = value; }
        }
        private string _category;
        public string Category
        {
            get => _category;
            set { _category = value; }
        }
        private bool _isrented;
        public bool IsRented
        {
            get => _isrented;
            set { _isrented = value; }
        }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set { _price = value; }
        }
        public Transport(string model, string color, int speed, int wheels, string category, decimal price)
        {
            Model = model;
            Color = color;
            Speed = speed;
            Wheels = wheels;
            Category = category;
            Price = price;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Speed: {Speed} км/ч");
            Console.WriteLine($"Number of wheels: {Wheels}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Price: {Price}");
        }
        public event RentStateChangedHandler RentStateChanged;

        public void Rent()
        {
            if (!IsRented)
            {
                IsRented = true;
                OnRentStateChanged();
            }
        }

        public void Return()
        {
            if (IsRented)
            {
                IsRented = false;
                OnRentStateChanged();
            }
        }

        protected virtual void OnRentStateChanged()
        {
            RentStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

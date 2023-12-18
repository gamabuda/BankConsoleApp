using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Transport
{
    class Bicycle : Transport
    {
        public override int Id { get { return 4; } }
        public override int Numberofwheels
        {
            get { return 2; }
            set { }
        }
        public string Motor
        {
            get => "-";
            set { }
        }
        public override void Insurance()
        {
            Console.WriteLine("Страховка не будет оформлена");
        }

        public decimal Price { get; set; }

        public string Print()
        {
            return $"Велосипед модель:{Model}, Цвет:{Color}, Категория прав:{Category}, Количество колес:{Numberofwheels}, Мотор:{Motor}, Скорость{Speed}";
        }
        public Bicycle(string speed, string color, string model)
        {
            Model = model;
            Color = color;
            Speed = speed;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Transport
{
    class Boat : Transport
    {
        public override int Id { get { return 3; } }
        public string Motor
        {
            get => "BDFLB";
            set { }
        }

        public decimal Price { get; set; }

        public string Print()
        {
            return $"Лодка модель:{Model}, Цвет:{Color}, Категория прав:{Category}, Мотор:{Motor}, Скорость{Speed}";
        }
        public Boat(string speed, string color, string model)
        {
            Model = model;
            Color = color;
            Speed = speed;
        }
    }
}
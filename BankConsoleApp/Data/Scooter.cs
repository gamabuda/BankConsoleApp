using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal class Scooter : Transport
    {
        public Scooter(string model, string color, int speed, string category, decimal price) : base(model, color, speed, 2, category, 2000)
        {
            Rent();
        }
        public override void Move()
        {
            IsRented = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Transport
{
    public delegate void TransportInfo(string msq);

     public class Transport
     {
        public virtual int Id { get; }
        public string Speed { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public virtual string Category { get { return "Нет"; } }
        public string IsRented { get { return "Нет"; } }
        public virtual int Numberofwheels { get { return 0; } set { } }
        public  string Motor { get; set; }
        public decimal Price { get; set; }
        public  void Print()
        {

        }
        public virtual void Insurance()
        {
            Console.WriteLine("Страховка оформлена");
        }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal interface Transport
    {
        public delegate void CreateTransport(string msg);
        public event CreateTransport? NewTransport;
        public string Model { get; set; }
        public int MaxSpeed { get; set; }

        public static void PrintData(string msg) => Console.WriteLine(msg);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal interface ITransport
    {
        public delegate void Message(string msg);
        public event Message? CarAction;
        public string Model { get; set; }
        public int MaxSpeed { get; set; }
        public int CurrentSpeed { get; set; }
        public string Color { get; set; }

        public void CarBreakdown();
    }
}

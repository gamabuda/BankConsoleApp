using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data.Transports
{
    public delegate void TransportInfo(string msg);
    public interface Transport
    {
        public event TransportInfo? Information;
        public decimal Price { get; }
        public void Operation(TransportInfo del) { }
        public abstract float Speed { get; set; }
        public abstract string Color { get; set; }
        public abstract string Model { get; set; }
        public abstract bool Rent { get; set; }
        public abstract string RightsCategory { get; set; }
        public abstract string Motor { get; set; }
        public abstract int NumWheels { get; set; }
        public abstract void PrintInfo(string msg);

        public virtual void CompareSpeeds(List<Transport> transports) { }
        public virtual void CheckingTheRent() { }
    }
}

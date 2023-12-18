using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.transport
{
    public delegate void TransportInfo(string msg);

    public interface Transport
    {
        public event TransportInfo? Information;
        public decimal Price { get; }
        public void RegisterHandler(TransportInfo del) { }
        public abstract string Model { get; set; }
        public abstract string Color { get; set; }
        public abstract int MaxSpeed { get; set; }
        public abstract bool IsRented { get; set; }
        public abstract void PrintInfo(string msg);

        public virtual void CompareSpeeds(List<Transport> transports) { }
        public virtual void CheckRentalStatus() { }
    }
}
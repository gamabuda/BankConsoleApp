using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    public delegate void TransportInfo(string msg);

    public interface Transport
    {
        public event TransportInfo? Information;
        public decimal Price { get; }
        public void Operation(TransportInfo del) { }
        public abstract string Model { get; set; }
        public abstract string Color { get; set; }
        public abstract int MaxSpeed { get; set; }
        public abstract int Category { get; set; }
        public abstract bool IsRented { get; set; }
        public abstract int WheelCount { get; set; }
        public abstract int HasMotor { get; set; }
        public abstract void Info(string msg);


        public virtual void CompareSpeeds(List<Transport> transports) { }
        public virtual void IsRented1() 
        {
            if (IsRented)
            {
                Console.WriteLine($"{Model}, {Color}, {MaxSpeed}, {Category}, {WheelCount}, {HasMotor}, однако у транспорта есть бронь, выберите другой транспорт..");
                
            }
            else
            {
                Console.WriteLine($"{Model}, {Color}, {MaxSpeed}, {Category}, {WheelCount}, {HasMotor}, транспорт - {Model} не забронирован");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.TransportData
{
    public interface ITransport
    {
        int Speed { get; set; }
        string Motor { get; set; }
        string Color { get; set; }
        string CategoryofRights { get; set; }
        string Model { get; set; }
        bool IsArended { get; set; }
        int Wheels { get; set; }

        decimal RentalCost { get; } // Стоимость аренды

        void Rent();
        void Return();
    }
}

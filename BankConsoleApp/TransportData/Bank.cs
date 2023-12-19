using BankConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankConsoleApp.TransportData;

namespace BankConsoleApp
{
    public class Bank
    {
        public event EventHandler<TransportEventArgs> TransportRented;
        public event EventHandler<TransportEventArgs> TransportReturned;
        public event EventHandler<BalanceChangedEventArgs> BalanceChanged;

        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (balance != value)
                {
                    balance = value;
                    OnBalanceChanged(new BalanceChangedEventArgs(balance));
                }
            }
        }

        // Оповещаем об изменении баланса
        protected virtual void OnBalanceChanged(BalanceChangedEventArgs e)
        {
            BalanceChanged?.Invoke(this, e);
        }

        // Аналогично для аренды и возврата транспорта
        protected virtual void OnTransportRented(TransportEventArgs e)
        {
            TransportRented?.Invoke(this, e);
        }

        protected virtual void OnTransportReturned(TransportEventArgs e)
        {
            TransportReturned?.Invoke(this, e);
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool RentTransport(ITransport transport)
        {
            if (balance >= transport.RentalCost)
            {
                balance -= transport.RentalCost;

                // Оповещаем об аренде транспорта
                OnTransportRented(new TransportEventArgs(transport));

                return true; // Аренда успешна
            }
            else
            {
                return false; // Недостаточно средств или транспорт уже арендован
            }
        }

        public void ReturnTransport(ITransport transport)
        {
            OnTransportReturned(new TransportEventArgs(transport));
        }
    }

    public class TransportEventArgs : EventArgs
    {
        public ITransport Transport { get; }

        public TransportEventArgs(ITransport transport)
        {
            Transport = transport;
        }
    }

    public class BalanceChangedEventArgs : EventArgs
    {
        public decimal NewBalance { get; }

        public BalanceChangedEventArgs(decimal newBalance)
        {
            NewBalance = newBalance;
        }
    }
}


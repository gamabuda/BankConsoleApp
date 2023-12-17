namespace BankAccount.Class
{
    public class BankAcc
    {
        private decimal _balance = 0;
        public decimal Balance { get => _balance; set { _balance = value; } }

        private string _accountNumber;
        public string AccountNumber { get => _accountNumber; set { _accountNumber = value; } }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value.Length < 8)
                    Console.WriteLine("Пароль должен быть длиннее 8 символов!");
                else
                {
                    _password = value;

                    ChangeFieldCompleted.Invoke("Password", value);
                }
            }
        }

        private string _fullname;
        public string Fullname
        {
            get => _fullname;
            set
            {
                _fullname = value;
                ChangeFieldCompleted.Invoke("Fullname", (string)value);
            }
        }

        List<ITransport> transports = new List<ITransport>();

        private delegate void BalanceOperation(BankAcc account, int sum);
        private event BalanceOperation BalanceOperationCompleted;

        private delegate void ChangedField(string fieldName, string value);
        private event ChangedField ChangeFieldCompleted;

        private delegate void AccountCreate(BankAcc account);
        private event AccountCreate AccountCreateCompleted;



        public BankAcc(string fullname, string password, decimal balance)
        {
            _accountNumber = Guid.NewGuid().ToString();
            _password = password;
            _fullname = fullname;
            _balance = balance;

            ChangeFieldCompleted = ChangeField;
            AccountCreateCompleted = CreateAccount;
            AccountCreateCompleted.Invoke(this);
        }
        public void Operation(string operation, BankAcc account, List<ITransport> transportList)
        {
            switch (operation)
            {
                case "1":
                    BalanceOperationCompleted = Replenish;

                    BalanceOperationCompleted += BalanceCheck;


                    Console.WriteLine("Enter sum of replenish");
                    int sum = Convert.ToInt32(Console.ReadLine());
                    BalanceOperationCompleted.Invoke(this, sum);
                    break;
                case "2":
                    BalanceOperationCompleted = Withdraw;

                    BalanceOperationCompleted += BalanceCheck;

                    Console.WriteLine("Enter sum of withdraw");
                    sum = Convert.ToInt32(Console.ReadLine());
                    BalanceOperationCompleted.Invoke(this, sum);
                    break;
                case "3":
                    BalanceOperationCompleted = BalanceCheck;

                    BalanceOperationCompleted.Invoke(this, 0);
                    break;
                case "4":
                    BalanceOperationCompleted = Translation;
                    BalanceOperationCompleted += BalanceCheck;

                    Console.WriteLine("Enter sum of translation");
                    sum = Convert.ToInt32(Console.ReadLine());
                    BalanceOperationCompleted.Invoke(account, sum);
                    break;
                case "5":
                    if (transportList.Count != 0)
                    {
                        Console.WriteLine("Choose transport:");
                        for (int i = 1; i <= transportList.Count; i++)
                        {
                            Console.WriteLine($"{i}.{transportList[i - 1].BuyPrint()}");
                        }
                        int choice = Convert.ToInt32(Console.ReadLine());

                        if (BuyTransport(transportList[choice - 1]))
                            transportList.RemoveAt(choice - 1);
                    }
                    else
                    {
                        Console.WriteLine("We don't have any transport for sale now");
                    }
                    break;
                case "6":
                    PrintTransportList();
                    break;
                default:
                    Console.WriteLine("Wrong operation");
                    break;
            }
        }

        private void Translation(BankAcc account, int sum)
        {
            if (_balance - sum >= 0)
            {
                account.Balance += sum;
                _balance -= sum;
                Console.WriteLine($"You've sent {(decimal)sum} to {account.Fullname}");
            }
            else
            {
                Console.WriteLine("Not enough money :(");
            }
        }

        private void Replenish(BankAcc account, int sum)
        {
            Balance += sum;
            Console.WriteLine("Replenish successed");
        }

        private void Withdraw(BankAcc account, int sum)
        {
            if (sum < Balance)
            {
                Balance -= sum;
                Console.WriteLine("Withdraw successed");
            }
            else Console.WriteLine("Not enough money");
        }

        private void BalanceCheck(BankAcc account, int sum)
        {
            Console.WriteLine($"Your balance: {Balance}\n");
        }

        private void BalanceCheck()
        {
            Console.WriteLine($"Your balance: {Balance}\n");
        }
        public bool Login(string pass)
        {
            if (!(pass == _password))
            {
                Console.WriteLine("Wrong password");
                return true;
            }
            return false;
        }
        public bool BuyTransport(ITransport transport)
        {
            if (transport.Cost <= Balance)
            {
                Balance -= transport.Cost;
                transports.Add(transport);
                Console.WriteLine($"You've bought {transport.ModelName} for {transport.Cost}.");
                BalanceCheck();
                return true;
            }
            else
                Console.WriteLine("You don't have enough money");

            BalanceCheck();
            return false;
        }

        public void PrintTransportList()
        {
            if (transports.Count != 0)
            {
                Console.WriteLine("Choose transport for checking");
                for (int i = 1; i <= transports.Count; i++)
                {
                    Console.WriteLine($"{i}.{transports[i - 1].BuyPrint()}");
                }

                int choice = Convert.ToInt32(Console.ReadLine()) - 1;
                transports[choice].Details();
            }
            else
            {
                Console.WriteLine("You don't have any transport");
            }
        }


        private void ChangeField(string fieldName, string value) => Console.WriteLine($"{fieldName} was changed. New value: {value}");
        private void CreateAccount(BankAcc account) => Console.WriteLine($"Bank Account created. \nAccount number: {account.AccountNumber} \nFullname: {account.Fullname} \nPassword: {account.Password} \nBalance: {account.Balance}\n");
    }
}

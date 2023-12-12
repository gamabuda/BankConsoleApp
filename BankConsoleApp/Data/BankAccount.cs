internal class BankAccount
{
    private decimal _balance = 1000;

    // Пример 1 (П1)
    // делегат void c аргументом string
    private delegate void NotificationHandler(string message);
    // событие NotificationHandler
    private event NotificationHandler IsNotify;

    // Пример 2 (П2)
    // делегат void c аргументом int
    private delegate void CommissionHandler(decimal sum);
    // событие TaxHandler
    private event CommissionHandler IsCommission;

    public BankAccount(string accountNumber, string password)
    {
        // П1
        // тут мы условно "пихаем" то что должно произойти во время отработки события
        IsNotify += PrintMessage;

        // П2
        // тут пример аналогичен с П1 за исключением того что
        // событие производит какие-либо мат.расчеты а не просто выводит что-то на консоль
        IsCommission += CommissionDeduction;

        AccountNumber = accountNumber;
        Password = password;

        Console.WriteLine($"Счет №{AccountNumber} открыт! Баланс счета {_balance}₽");
    }

    public string AccountNumber { get; set; }
    public string Password { get; set; }
    public decimal Balance
    {
        get { return _balance; }
        private set
        {
            // П1
            // вызываем событие
            IsNotify?.Invoke($"Баланс счета {AccountNumber} был изменен. Остаток {value}₽");
            _balance = value;
        }
    }

    // П2
    // метод вычета комиссии
    private void CommissionDeduction(decimal sum)
    {
        var commission = sum * (decimal)0.05;
        Console.WriteLine($"Комиссия за операцию -{commission}₽");
        Balance -= commission;
    }

    // П1
    // метод вывода сообщения
    public void PrintMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    // П2
    // перевод деняк с счета на счет
    public void TransferFunds(BankAccount account, decimal sum)
    {
        if (_balance - sum > 0)
        {
            Console.WriteLine($"Перевод средств на сумму {sum}₽ c счета {AccountNumber} на счет {account.AccountNumber}");
            
            Balance -= sum;
            account.Balance += sum;
            // П2
            // вызываем событие
            IsCommission?.Invoke(sum);

        }
        else
        {
            Console.WriteLine($"Недостаточно средств для транзакции!");
        }
    }

    // П2
    // снятие деняк (типо наличка)
    public void WithdrawingFunds(decimal sum)
    {
        if (_balance - sum > 0)
        {
            Console.WriteLine($"Cнятие наличных на сумму {sum}₽ c счета {AccountNumber}");
            
            Balance -= sum;
            // П2
            // вызываем событие
            IsCommission?.Invoke(sum);
        }
        else
        {
            Console.WriteLine($"Недостаточно средств для транзакции!");
        }
    }
}
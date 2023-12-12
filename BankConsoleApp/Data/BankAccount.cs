internal class BankAccount
{
    private decimal _balance = 100;

    // Пример 1 (П1)
    // делегат void c аргументом string
    private delegate void NotificationHandler(string message);
    // событие NotificationHandler
    private event NotificationHandler Notify;

    public BankAccount(string accountNumber, string password)
    {
        // П1
        // тут мы условно "пихаем" то что должно произойти во время отработки события
        Notify += PrintMessage;

        AccountNumber = accountNumber;
        Password = password;

        Console.WriteLine($"Счет №{AccountNumber} открыт! Баланс счета {_balance}₽");
    }

    public string AccountNumber { get; set; }
    public string Password { get; set; }
    public decimal Balance
    {
        get { return _balance; }
        set
        {
            // П1
            // вызываем событие
            Notify?.Invoke($"Баланс счета {AccountNumber} был изменен. Остаток {value}₽");
            _balance = value;
        }
    }

    // П1
    // метод вывода сообщения
    public void PrintMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    public void Translation(BankAccount account, int total)
    {
        if (_balance - total > 0)
        {
            account.Balance += total;
            _balance -= total;
        }
        else
        {
            Console.WriteLine("Not enf money");
        }
    }
}
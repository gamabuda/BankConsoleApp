
using BankConsoleApp.Transport;

public interface IBankAccount
{
    string FullName { get; }
    string AccountNumber { get; }
    string Password { get; }
    decimal Balance { get; }

    event ConsoleColorHandler OnColorMessage;

    bool Try2Replenish(decimal sum);
    bool Try2Withdraw(decimal sum);
}

public delegate void ConsoleColorHandler(string msg, TextColor color);

public enum TextColor
{
    Green,
    Red,
    Default
}
public class BankAccount : IBankAccount
{
    private decimal _balance;

    private delegate void ConsoleColorHandler(string msg, TextColor color);
    private event ConsoleColorHandler _isSendColorMessage;
    public event global::ConsoleColorHandler OnColorMessage;

    public BankAccount(string fullName, string password, decimal balance = 0)
    {
        AccountNumber = Guid.NewGuid().ToString();

        _balance = balance;
        FullName = fullName;
        Password = password;

        Console.WriteLine($"New BankAccount was created!\n\nWelcome {FullName}" +
            $"\n\tAccount number: {AccountNumber}" +
            $"\n\tPassword: {HidePassword()}" +
            $"\n\tBalance: {Balance}$\n");

        _isSendColorMessage = PrintMessage;
    }

    public string FullName { get; }
    public string AccountNumber { get; private set; }
    public string Password { get; private set; }
    public decimal Balance
    {
        get => _balance;
        private set
        {
            if (_balance > value)
                _isSendColorMessage?.Invoke($"-{_balance - value}$ \nAccount number: {AccountNumber}\nDateTime: {DateTime.Now}", TextColor.Red);
            else
                _isSendColorMessage?.Invoke($"+{value - _balance}$ \nAccount number: {AccountNumber}\nDateTime: {DateTime.Now}", TextColor.Green);

            _balance = value;
            Console.WriteLine($"Result: {Balance}$\n");
        }
    }



    private void PrintMessage(string msg, TextColor color)
    {
        switch (color)
        {
            case TextColor.Green:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case TextColor.Red:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case TextColor.Defult:
                Console.ResetColor();
                break;
        }

        Console.WriteLine(msg);

        Console.ResetColor();
    }

    private string HidePassword()
    {
        string s = "";
        for (int i = 0; i < Password.Length; i++)
        {
            s += '*';
        }
        return s;
    }

    public bool Try2Replenish(decimal sum)
    {
        if (sum > 500000)
        {
            _isSendColorMessage?.Invoke("You're over the limit\n", TextColor.Red);
            return false;
        }

        Balance += sum;
        return true;
    }

    public bool Try2Withdraw(decimal sum)
    {
        if (_balance - sum < 0)
        {
            _isSendColorMessage?.Invoke("You don't have enough money.\n", TextColor.Red);
            return false;
        }

        Balance -= sum;
        return true;
    }

    private enum TextColor
    {
        Green,
        Red,
        Defult
    }

    public void Arend(Transport transport)
    {
        decimal arenda = transport.Price;
        Balance -= arenda;
        Console.WriteLine($"Был арендован транспорт {transport}. Списана сумма со счета в размере {arenda}. Остаток: {Balance}");
    }
}
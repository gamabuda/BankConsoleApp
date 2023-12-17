using System;

public class BankAccount
{
    private decimal _balance;
    private int _passwordAttempts;
    private bool _isLocked;

    private delegate void ConsoleColorHandler(string msg, TextColor color);
    private event ConsoleColorHandler _isSendColorMessage;

    private delegate void PasswordAttemptHandler(string password);
    private event PasswordAttemptHandler _passwordAttempt;

    private delegate void OverLimitHandler(string password, decimal sum);
    private event OverLimitHandler _overLimit;

    private delegate void OverWithdrawHandler(string password, decimal sum);
    private event OverWithdrawHandler _overWithdraw;

    public BankAccount(string fullName, string password, decimal balance = 0)
    {
        AccountNumber = Guid.NewGuid().ToString();

        _balance = balance;
        FullName = fullName;
        Password = password;
        _passwordAttempt = CheckPassword;
        _overLimit = CheckOverLimit;
        _overWithdraw = CheckOverWithdraw;

        Console.WriteLine($"New BankAccount was created!\n\nWelcome {FullName}" +
            $"\n\tAccount number: {AccountNumber}" +
            $"\n\tPassword: {HidePassword()}" +
            $"\n\tBalance: {Balance}$\n");

        _isSendColorMessage = PrintMessage;
    }

    private void CheckOverWithdraw(string password, decimal sum)
    {
        if (_balance - sum < 0)
        {
            _isSendColorMessage?.Invoke("You don't have enough money.\n", TextColor.Red);
        }
    }

    private void CheckOverLimit(string password, decimal sum)
    {
        if (sum > 500000)
        {
            _isSendColorMessage?.Invoke("You're over the limit.\n", TextColor.Blue);
        }
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

    private void CheckPassword(string password)
    {
        if (password != Password)
        {
            _isSendColorMessage?.Invoke("Incorrect password.\n", TextColor.Yellow);
            _passwordAttempts++;
            if (_passwordAttempts >= 3)
            {
                _isSendColorMessage?.Invoke("You have exceeded the number of attempts. Account locked.\n", TextColor.Red);
                _isLocked = true;
            }
            else
            {
                _isSendColorMessage?.Invoke($"You have {3 - _passwordAttempts} attempts left.\n", TextColor.Red);
            }
        }
        else
        {
            _passwordAttempts = 0;
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
            case TextColor.Yellow:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case TextColor.Blue:
                Console.ForegroundColor = ConsoleColor.Blue;
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

    public bool Try2Transfer(string password, decimal sum, string recipientAccountNumber)
    {
        if (_isLocked)
        {
            Console.WriteLine("Account is locked.");
            return false;
        }
        _passwordAttempt?.Invoke(password);

        if (sum > 500000)
        {
            _isSendColorMessage?.Invoke("You're over the limit\n", TextColor.Blue);
            return false;

        }

        Balance += sum;
        return true;
    }

    public bool Try2Withdraw(string password, decimal sum)
    {
        if (_isLocked)
        {
            Console.WriteLine("Account is locked.");
        }
        _passwordAttempt?.Invoke(password);
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
        Defult,
        Yellow,
        Blue
    }
}
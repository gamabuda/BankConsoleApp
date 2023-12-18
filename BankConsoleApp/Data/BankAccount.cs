using BankConsoleApp.Data;

public class BankAccount
{
    private decimal _balance;
    private string _fullname;
    private string _id;
    private string _password;
    public List<ITransport> transports = new();

    public decimal Balance { get { return _balance; } set { _balance = value; } }
    public string FullName { get { return _fullname; } set { _fullname = value; } }

    private delegate void DoOperation(int sum);
    private event DoOperation DoOperationCompleted;

    public BankAccount(string fullname, decimal balance, string password)
    {
        _fullname = fullname;
        _balance = balance;
        _password = password;

        _id = Guid.NewGuid().ToString();

        DoOperationCompleted += AccountCreated;
        DoOperationCompleted.Invoke(0);
    }

    public void doOperation(string operName, int sum)
    {
        switch (operName)
        {
            case "plusDengi":
                DoOperationCompleted = plusDengi;
                break;
            case "minusDengi":
                DoOperationCompleted = minusDengi;
                break;
        }
        DoOperationCompleted(sum);
    }

    public void plusDengi(int sum)
    {
        _balance += sum;
        Console.WriteLine($"Вы добавили деньги({sum}). Ваш баланс: {_balance}");
    }

    public void minusDengi(int sum)
    {
        if (_balance > sum)
        {
            _balance -= sum;
            Console.WriteLine($"Вы сняли деньги({sum}). Ваш баланс: {_balance}");
        }
    }
    public void AccountCreated(int sum) => Console.WriteLine($"Аккаунт создан. ФИО: {_fullname}, ID: {_id}, Пароль: {_password}");

    public void vivodMashini()
    {
        foreach(ITransport transport in transports)
        {
            Console.WriteLine(transport.ModelName);
        }
    }

    public void vivod() => Console.WriteLine($"{FullName}, {Balance}, {_id}");
>>>>>>> Stashed changes
}

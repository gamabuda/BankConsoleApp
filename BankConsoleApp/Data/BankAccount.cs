namespace BankAccount
{
    public class Account
    {
        private delegate void ConsoleColorHandler(string msg, TextColor color);
        private event ConsoleColorHandler _isSendColorMessage;

        private int _sum;
        private int textColorIndex = 0;
        public int Sum 
        {
            get => _sum;
            private set
            {
                if(textColorIndex == 1) 
                {
                    _isSendColorMessage?.Invoke($"-{_sum - value}$ \nAccount number: {Login}\nDateTime: {DateTime.Now}", TextColor.DarkYellow);
                }
                else if(textColorIndex == 2) 
                {
                    _isSendColorMessage?.Invoke($"+{_sum + value}$ \nAccount number: {Login}\nDateTime: {DateTime.Now}", TextColor.Green);
                }
                else if (textColorIndex == 3) 
                {
                    _isSendColorMessage?.Invoke("Недостаточно средств", TextColor.Red);
                }

                _sum = value;

                if (textColorIndex != 0) { Balance(); }
            }
        }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public int ID { get; set; }
        public Account(int sum, string login, string password, int iD)
        {
            Sum = sum;
            Login = login;
            Password = password;
            ID = iD;

            _isSendColorMessage += PrintMessage;

            _isSendColorMessage?.Invoke($"Спасибо, что выбрали нас, {Login}", TextColor.Green);
        }

        public void Put(int _sum)
        {
            textColorIndex = 2;
            Sum += _sum;
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                textColorIndex = 1;
                Sum -= sum + TakeCommission(sum);
            }
            else 
            {
                textColorIndex = 3;
                Sum -= 0;
            }
        }
        public void Balance() => Console.WriteLine(" На вашем счету " + Sum + "$");      
        public void MonetaryTransactions(ConsoleKeyInfo key)
        {
            Console.WriteLine("Введите сумму:");
            int sum = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (key.Key == ConsoleKey.D3) { Put(sum); }
            if (key.Key == ConsoleKey.D4) { Take(sum); }
        }
        public void ChangeLogin(string _login) => Login = _login;
        public void ChangePassword(string _password) => Password = _password;
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
                case TextColor.DarkYellow:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
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
        private int TakeCommission(int _sum)
        {
            _sum = (int)(_sum * 0.01);
            _isSendColorMessage?.Invoke($" Взята коммиссия {_sum}$", TextColor.Blue);
            return _sum;
        }

        private enum TextColor
        {
            Red,
            DarkYellow,
            Green,
            Blue,
            Defult
        }

    }
}

BankAccount account1 = new BankAccount("295812932", "qwerty");
BankAccount account2 = new BankAccount("105233205", "123456");

account1.TransferFunds(account2, 60);
account1.WithdrawingFunds(10);

Console.ReadKey();
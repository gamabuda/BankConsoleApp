BankAccount account1 = new BankAccount("295812932", "qwerty");
BankAccount account2 = new BankAccount("105233205", "123456");

account1.Balance = 200;
account1.Translation(account2, 50);
Console.ReadKey();
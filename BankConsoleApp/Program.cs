using BankConsoleApp.Data;

BankAccount account1 = new BankAccount("295812932", "qwerty");
BankAccount account2 = new BankAccount("112432144", "zxcvbn");
account1.Transaction(account2, 599);
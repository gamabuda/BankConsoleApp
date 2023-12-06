using BankConsoleApp.Data;

BankAccount account1 = new BankAccount("295812932", "qwerty");
BankAccount account2 = new BankAccount("123456789", "zxcvbn");

account1.Transaction(account2, 999);
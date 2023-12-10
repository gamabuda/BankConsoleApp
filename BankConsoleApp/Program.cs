using BankConsoleApp.Data;

BankAccount account = new BankAccount("295812932", "qwerty", 1000);

BankAccount.DepositOp depositDel = new BankAccount.DepositOp(account.Deposit);
depositDel.Invoke(account, 100);

BankAccount.WithdrawalOp withdrawalDel = new BankAccount.WithdrawalOp(account.Withdrawal);
withdrawalDel.Invoke(account, 50);

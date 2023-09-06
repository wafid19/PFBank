

using PFBank;

BankAccount account1 = new BankAccount("Mosharraf",100000);

Console.WriteLine(account1.AcNumber);

BankAccount acc2 = new BankAccount("Al Amin", 200000);
acc2.MakeDiposit(20000, DateTime.Now, "acc2");

acc2.MakeWithdrawal(50000, DateTime.Now, "Alamin");

Console.WriteLine(acc2.GetAccountHistory());

Console.WriteLine(acc2.Balance);
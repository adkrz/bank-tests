using BankProject;

var dateTimeService = new DateTimeService();

var bank1 = new Bank("PKO", dateTimeService);
var acc1 = new BankAccount("Jan Kowalski", 11.99);
bank1.AddAccount(acc1);
var acc2 = new BankAccount("Tomasz Nowak", 22.15);
bank1.AddAccount(acc2);

var bank2 = new Bank("ING", dateTimeService);
var acc3 = new BankAccount("Ewa Nowak", 800.15);
bank2.AddAccount(acc3);
var acc4 = new BankAccount("Adam Testowy", 0.01);
bank2.AddAccount(acc4);

var banks = new[] {bank1, bank2};

var logger = new ConsoleLogger();

void PrintBanks()
{
    foreach (var bank in banks)
        Console.WriteLine(bank);
}

PrintBanks();

Console.WriteLine();
acc1.Transfer(acc2, 1, logger);
Console.WriteLine();
PrintBanks();
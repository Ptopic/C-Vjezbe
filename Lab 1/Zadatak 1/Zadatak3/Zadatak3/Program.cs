using Zadatak3.Classes;
using Zadatak3.Enums;

namespace Zadatak3
{
    internal class Program
    {
        public const int MAX_ACCOUNTS = 5;
        public static int curAccountIndex = 0;

        static void Main(string[] args)
        {
            Aplikacija();
        }

        private static void Aplikacija()
        {
            var exit = false;
            var bankAccounts = new BankAccount[MAX_ACCOUNTS];

            // Init all objects
            for(int i = 0; i < MAX_ACCOUNTS;i++)
            {
                var bankAccount = new BankAccount();
                bankAccounts[i] = bankAccount;
            }

            while (!exit)
            {
                Console.WriteLine(@"
---------------------
1 - Unesi novi racun
2 - Ispisi sve racune
0 - Quit
---------------------");
    
            int.TryParse(Console.ReadLine().Trim(), out int input);

                if (input < 0 || input > 2) break;

                Console.Clear();
                switch (input)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        EnterAccount(bankAccounts);
                        break;
                    case 2:
                        PrintAccounts(bankAccounts);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static void EnterAccount(BankAccount[] bankAccounts)
        {
            Console.Clear();
            Console.WriteLine(@"
---------------------
Pravljenje racuna:
---------------------");

            if (curAccountIndex == MAX_ACCOUNTS)
            {
                Console.WriteLine("Maksimalni broj racuna dosegnut");
                return;
            }
            else
            {
                Console.WriteLine("\nEnter the account number:");
                bankAccounts[curAccountIndex].number = Console.ReadLine();

                Console.WriteLine("\nEnter the account amount:");
                var amountInput = double.Parse(Console.ReadLine());
                bankAccounts[curAccountIndex].amount = amountInput;

                Console.WriteLine(@"
Choose the account type:
+--- Account Types ---+
| 0 - Savings         |
| 1 - Current account |
| 2 - Giro account    |
+---------------------+");

                int.TryParse(Console.ReadLine().Trim(), out int accountTypeNumber);
                if (accountTypeNumber < 0 || accountTypeNumber > 2) return;
                bankAccounts[curAccountIndex].accountType = (AccountTypes)accountTypeNumber;
            }

            curAccountIndex++;
            Console.WriteLine("Novi racun napravljen");
        }

        private static void PrintAccounts(BankAccount[] bankAccounts)
        {
            Console.Clear();
            Console.WriteLine(@"
---------------------
Svi racuni:
---------------------");
            foreach (var bankAccount in bankAccounts)
            {
                Console.WriteLine($"\nAccount Number. {bankAccount.number}, " +
                    $"Amount: {bankAccount.amount:C}, " +
                    $"Type: {bankAccount.accountType}");
            }

        }
    }
}
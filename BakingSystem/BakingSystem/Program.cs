using System;
using System.Collections.Generic;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pre-existing accounts
            List<Account> accounts = new List<Account>
            {
                new Account { ID = 1, Name = "John", Balance = 50000m, AccountType = "Savings", Email = "humna@example.com" },
                new Account { ID = 2, Name = "Joe", Balance = 60000m, AccountType = "Checking", Email = "hania@example.com" },
                new Account { ID = 3, Name = "Guienevere", Balance = 45000m, AccountType = "Savings", Email = "fizza@example.com" },
                new Account { ID = 4, Name = "Luna", Balance = 60000m, AccountType = "Checking", Email = "zainab@example.com" }
            };

            bool exit = false;

            Console.WriteLine("Welcome to H-Bank\n");

            while (!exit)
            {
                Console.WriteLine("Welcome to the Banking System");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Display Account Details");
                Console.WriteLine("6. Exit");
                Console.Write("Please select an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateAccount(accounts);
                        break;
                    case 2:
                        Deposit(accounts);
                        break;
                    case 3:
                        Withdraw(accounts);
                        break;
                    case 4:
                        Transfer(accounts);
                        break;
                    case 5:
                        DisplayAccountDetails(accounts);
                        break;
                    case 6:
                        exit = true;
                        Console.WriteLine("Thank you for choosing us!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine(); // Add a line to show space between options and starting message
            }
        }

        static void CreateAccount(List<Account> accounts)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());
            Console.Write("Enter account type (e.g., Savings, Checking): ");
            string accountType = Console.ReadLine();
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            int id = accounts.Count + 1;

            Account newAccount = new Account
            {
                ID = id,
                Name = name,
                Balance = balance,
                AccountType = accountType,
                Email = email
            };

            accounts.Add(newAccount);
            Console.WriteLine("Account created successfully!");
        }

        static void Deposit(List<Account> accounts)
        {
            Console.Write("Enter account ID: ");
            int id = int.Parse(Console.ReadLine());
            Account account = accounts.Find(a => a.ID == id);

            if (account != null)
            {
                Console.Write("Enter amount to deposit: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                account.Balance += amount;
                Console.WriteLine("Deposit successful!");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void Withdraw(List<Account> accounts)
        {
            Console.Write("Enter account ID: ");
            int id = int.Parse(Console.ReadLine());
            Account account = accounts.Find(a => a.ID == id);

            if (account != null)
            {
                Console.Write("Enter amount to withdraw: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                if (account.Balance >= amount)
                {
                    account.Balance -= amount;
                    Console.WriteLine("Withdrawal successful!");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void Transfer(List<Account> accounts)
        {
            Console.Write("Enter source account ID: ");
            int sourceId = int.Parse(Console.ReadLine());
            Account sourceAccount = accounts.Find(a => a.ID == sourceId);

            if (sourceAccount != null)
            {
                Console.Write("Enter destination account ID: ");
                int destinationId = int.Parse(Console.ReadLine());
                Account destinationAccount = accounts.Find(a => a.ID == destinationId);

                if (destinationAccount != null)
                {
                    Console.Write("Enter amount to transfer: ");
                    decimal amount = decimal.Parse(Console.ReadLine());

                    if (sourceAccount.Balance >= amount)
                    {
                        sourceAccount.Balance -= amount;
                        destinationAccount.Balance += amount;
                        Console.WriteLine("Transfer successful!");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance.");
                    }
                }
                else
                {
                    Console.WriteLine("Destination account not found.");
                }
            }
            else
            {
                Console.WriteLine("Source account not found.");
            }
        }

        static void DisplayAccountDetails(List<Account> accounts)
        {
            Console.Write("Enter account ID: ");
            int id = int.Parse(Console.ReadLine());
            Account account = accounts.Find(a => a.ID == id);

            if (account != null)
            {
                Console.WriteLine($"Account ID: {account.ID}");
                Console.WriteLine($"Name: {account.Name}");
                Console.WriteLine($"Balance: {account.Balance}");
                Console.WriteLine($"Account Type: {account.AccountType}");
                Console.WriteLine($"Email: {account.Email}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }

    class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public string Email { get; set; }
    }
}

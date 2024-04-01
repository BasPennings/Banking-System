using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_System.Account;
using Banking_System.Banks;

namespace Banking_System
{
    internal class UserInterface
    {
        public void PrintMainMenu(IBank[] banks)
        {
            Console.WriteLine("""
                [Main Menu]
                Welcome to the banking system!

                Here is a list of the banks:
                """);

            for (int i = 0; i < banks.Length; i++) Console.WriteLine($"{i + 1}. {banks[i].Name} - {banks[i].Description}");

            Console.WriteLine("""

                For further actions, please enter the number of the bank which you would like to proceed with:
                """);
        }

        public void PrintBankMenu(IBank selectedBank)
        {
            Console.WriteLine($"""
                [Bank Menu]
                Welcome to {selectedBank.Name}.
                
                {selectedBank.Description}

                Please login to your account, or create a new one:
                1. Login
                2. Create account
                """);
        }

        public void PrintLoginMenu(IBank bank)
        {
            Console.WriteLine($"""
                [Bank Login Menu]
                Please login into your {bank.Name} account.
                """);
        }

        public void PrintCreateAccountMenu(IBank bank)
        {
            Console.WriteLine($"""
                [Create Account Menu]
                You are about to make a {bank.Name} account.
                """);
        }

        public void PrintBankAccountMenu(BankAccount bankAccount)
        {
            string username = $"{bankAccount.AccountHolderInformation.FirstName} {bankAccount.AccountHolderInformation.Infix} {bankAccount.AccountHolderInformation.LastName}.";
            Console.WriteLine($"""
                [Bank Account Menu]
                Welcome to your {bankAccount._bank.Name} account, {username}.



                """);
        }

        public string? GetUserInput() => Console.ReadLine();
        
        public void PrintMessage(string message) => Console.WriteLine(message);

        public void PrintFeedback(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
        }

        public void Clear() => Console.Clear();
    }
}

using Banking_System.Account;
using Banking_System.Banks;

namespace Banking_System
{
    internal class Program
    {
        private enum UserOptions
        {
            Login,
            CreateAccount
        }

        private static UserInterface _userInterface = new UserInterface();

        private static void Main(string[] args)
        {
            IBank[] banks =
            [
                new Rabobank(),
                new ISBN()
            ];

            foreach (IBank _ in banks)
            {
                _.LoadBankAccounts();
            }


            IBank selectedBank = GetSelectedBank(banks);
            UserOptions chosenOption = GetUserBankOption(selectedBank);


            BankAccount userBankAccount;
            if (chosenOption == UserOptions.Login)
            {
                userBankAccount = GetUserBankAccount(selectedBank);
            }
            else {
                userBankAccount = GetUserBankAccount(selectedBank);
            }

            _userInterface.PrintBankAccountMenu(userBankAccount);
        }

        private static IBank GetSelectedBank(IBank[] banks)
        {
            _userInterface.PrintMainMenu(banks);

            int userChoice;
            while (!int.TryParse(_userInterface.GetUserInput(), out userChoice) || userChoice <= 0 || userChoice > banks.Length)
            {
                _userInterface.Clear();
                _userInterface.PrintMainMenu(banks);
            }

            _userInterface.Clear();
            return banks[userChoice - 1];
        }

        private static UserOptions GetUserBankOption(IBank selectedBank)
        {
            _userInterface.PrintBankMenu(selectedBank);

            int userChoice;
            int validOptions = 2;
            while (!int.TryParse(_userInterface.GetUserInput(), out userChoice) || userChoice <= 0 || userChoice > validOptions)
            {
                _userInterface.Clear();
                _userInterface.PrintBankMenu(selectedBank);
            }

            _userInterface.Clear();
            return userChoice == 1 ? UserOptions.Login : UserOptions.CreateAccount;
        }

        private static BankAccount GetUserBankAccount(IBank bank)
        {
            _userInterface.PrintLoginMenu(bank);

            BankAccount? bankAccount = null;
            while (bankAccount == null)
            {
                string? username = GetInputFieldResult("Username: ");
                string? PIN = GetInputFieldResult("PIN: ");

                if (username != null && PIN != null) bankAccount = bank.GetAccount(username, PIN);

                //_userInterface.Clear();
                if (bankAccount == null)
                {
                    _userInterface.PrintLoginMenu(bank);
                    _userInterface.PrintFeedback("Incorrect username or PIN!");
                }
            }

            return bankAccount;
        }

        private static string? GetInputFieldResult(string fieldText)
        {
            Console.WriteLine();
            _userInterface.PrintMessage(fieldText);
            return _userInterface.GetUserInput();
        }
    }
}

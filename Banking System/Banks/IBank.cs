using Banking_System.Account;

namespace Banking_System.Banks
{
    internal interface IBank
    {
        public string Name { get; }
        public string Description { get; }
        public Currency Currency { get; }
        BankAccount[] BankAccounts { get; }

        public void LoadBankAccounts();

        public BankAccount? GetAccount(string username, string password); 
    }
}

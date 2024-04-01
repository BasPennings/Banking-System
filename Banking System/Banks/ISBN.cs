using Banking_System.Account;

namespace Banking_System.Banks
{
    internal class ISBN : IBank
    {
        public string Name => "ISBN";
        public string Description => "Dutch bank 2";

        public Currency Currency => Currency.EUR;

        public BankAccount[] BankAccounts { get; private set; }

        public void LoadBankAccounts()
        {
            BankAccounts = [
                new BankAccount(
                    this,

                    new AccountHolderInformation {
                        FirstName = "Bas",
                        Infix = "",
                        LastName = "Poeters",
                        Username = "Bas Poeters",

                        Address = new Address {
                            Street = "Boterhoek",
                            City = "Lennisheuvel",
                            State = "Boxtel",
                            PostalCode = "1234AB"
                        },

                        PhoneNumber = "0612345678",
                        EmailAddress = "Bas.Peters@gmail.com"
                    },

                    new Dictionary<string, string>() {
                        { "favourite food", "pizza" },
                        { "name son", "bazzeman" },
                        { "daily activity", "gaming" }
                    },

                    new AccountPreferences {
                        StatementDeliveryMethod = StatementDeliveryMethods.PaperStatement,
                        AlertPreferences = AlertPreferences.LowBalanceAlerts
                    })
            ];
        }

        public BankAccount? GetAccount(string username, string PIN)
        {
            foreach (var account in BankAccounts)
            {
                if (account.ValidateUsername(username) && account.ValidatePersonalIdentificationNumber(PIN)) return account;
            }

            return null;
        }
    }
}

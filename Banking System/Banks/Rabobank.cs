using Banking_System.Account;

namespace Banking_System.Banks
{
    internal class Rabobank : IBank
    {
        public string Name => "Rabobank";
        public string Description => "Dutch bank";

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
                        LastName = "Peters",
                        Username = "Bas Peters",

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
            foreach (var _ in BankAccounts)
            {
                if (_.ValidateUsername(username) && _.ValidatePersonalIdentificationNumber(PIN)) return _;
            }

            return null;
        }
    }
}

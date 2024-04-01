using Banking_System.Banks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Account
{
    public struct AccountHolderInformation
    {
        public required string FirstName { get; set; }
        public required string Infix { get; set; }
        public required string LastName { get; set; }
        public required Address Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EmailAddress { get; set; }
    }

    public struct AccountDetails
    {
        public long PrimaryAccountNumber { get; private set; } // (PAN) 16-digit number.
        public required Currency Currency { get; set; }
        public required decimal AccountBalance { get; set; }

        private static Random? random;

        public AccountDetails()
        {
            random ??= new Random();

            int panLength = 16;
            PrimaryAccountNumber = random.Next((int)Math.Pow(10, panLength - 1), (int)Math.Pow(10, panLength));
        }
    }

    public struct TransactionHistory
    {
        public List<TransactionRecord> Deposits { get; set; } // Records of money deposited into the account, including the date, amount, and source.
        public List<TransactionRecord> Withdrawals { get; set; } // Records of money withdrawn from the account, including the date, amount, and recipient.
        public List<TransactionRecord> Transfers { get; set; } // Records of funds transferred between accounts, including the date, amount, and recipient account.
    }

    public struct SecurityInformation
    {
        public string PersonalIdentificationNumber { get; private set; } // (PIN) A numeric code used for ATM withdrawals and other secure transactions.
        public required Dictionary<string, string>? SecurityQuestions { get; set; } // Additional security measures for verifying the identity of the account holder.
        private static Random? random;

        public SecurityInformation() {
            random ??= new Random();

            int pinLength = 5;
            PersonalIdentificationNumber = random.Next((int)Math.Pow(10, pinLength - 1), (int)Math.Pow(10, pinLength)).ToString();
            Console.WriteLine(PersonalIdentificationNumber);
        }
    }

    public struct AccountStatus
    {
        public required bool IsActive { get; set; } // Indicates whether the account is currently active or inactive.
        public required bool IsOpen { get; set; } // Indicates whether the account is open for transactions or has been closed.
    }

    public struct AccountPreferences
    {
        public required StatementDeliveryMethods StatementDeliveryMethod { get; set; } // Preferences for receiving account statements (e.g., paper statements or electronic statements).
        public required AlertPreferences AlertPreferences { get; set; } // Preferences for receiving account alerts (e.g., low balance alerts, transaction notifications).
    }

    internal class BankAccount
    {
        public readonly IBank _bank;
        public AccountHolderInformation AccountHolderInformation { get; }
        private AccountDetails _accountDetails;
        private TransactionHistory? _transactionHistory;
        private readonly SecurityInformation _securityInformation;
        private AccountStatus _accountStatus;
        private AccountPreferences _accountPreferences;

        public BankAccount(IBank bank,
            AccountHolderInformation accountHolderInformation,
            Dictionary<string, string> securityQuestions,
            AccountPreferences accountPreferences
        ) {
            _bank = bank;
            AccountHolderInformation = accountHolderInformation;
            _accountPreferences = accountPreferences;

            _accountDetails = new AccountDetails {
                Currency = bank.Currency,
                AccountBalance = 0
            };

            _securityInformation = new SecurityInformation
            {
                SecurityQuestions = securityQuestions
            };

            _accountStatus = new AccountStatus
            {
                IsActive = true,
                IsOpen = true
            };
        }

        //public bool ValidateUsername(string username)
        //    => $"{AccountHolderInformation.FirstName} {AccountHolderInformation.Infix} {AccountHolderInformation.LastName}" == username;

        //public bool ValidatePersonalIdentificationNumber(string personalIdentificationNumber)
        //    => _securityInformation.PersonalIdentificationNumber == personalIdentificationNumber;

        public bool ValidateUsername(string username)
        {
            string correctUsername = $"{AccountHolderInformation.FirstName} {AccountHolderInformation.Infix !?? " "}{AccountHolderInformation.LastName}";
            Console.WriteLine($"Given username: {username} | Correct username {correctUsername}");
            return correctUsername == username;
        }

        public bool ValidatePersonalIdentificationNumber(string personalIdentificationNumber)
        {
            Console.WriteLine($"Given PIN: {personalIdentificationNumber} | Correct PIN {_securityInformation.PersonalIdentificationNumber}");
            return _securityInformation.PersonalIdentificationNumber == personalIdentificationNumber;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_System.Account;
using Banking_System.Banks;

namespace Banking_System
{
    internal struct CreditCard
    {
        public IBank Bank;
        public BankAccount BankAccount;
        public string CardUuid;
        private int _pinCode;
        private int _euro;

        private long _primaryAccountNumber; // (PAN) 16-digit number.
        private string _cardholderName; // Full name of the cardholder as written on the card.
        private DateTime _expirationDate; // The month and year when the card expires.
        private int _serviceCode; // A three-digit code indicating the services and restrictions applied to the card.
        private string _issuerIdentificationNumber; // (IIN) The first six digits of the PAN, which identify the card issuer.

        private static Random? _random;

        public CreditCard(IBank bank, BankAccount bankAccount, string country)
        {
            _random ??= new Random();

            Bank = bank;
            BankAccount = bankAccount;
            CardUuid = country + Guid.NewGuid().ToString();
            _pinCode = 
            _euro = 0;
        }
    }
}

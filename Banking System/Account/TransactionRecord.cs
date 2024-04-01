namespace Banking_System.Account
{
    public struct TransactionRecord
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string SourceOrRecipient { get; set; }
    }
}

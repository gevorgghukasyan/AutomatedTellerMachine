using System;

namespace Common
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int CardId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public bool Withdraw { get; set; }
    }
}

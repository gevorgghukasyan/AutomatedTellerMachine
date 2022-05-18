using System;

namespace Common
{
    public class Card
    {
        public int CardId { get; set; }
        public string AccountNumber { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public string Password { get; set; }
        public DateTime Validation { get; set; }
        public string Guid { get; set; }
        public bool Blocked { get; set; }
    }
}

using System;

namespace Common
{
    public class User
    {
        public int Id { get; set; }
        public string PassportSerial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public decimal Tax { get; set; }
    }
}

using SQLite;
using System;
namespace imPACt.Tables
{

    public class RegisterUserTable
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }
        public string ResearchInterest { get; set; }
        public string Year { get; set; }

    }
    
}

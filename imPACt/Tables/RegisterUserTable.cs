using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

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
        public string School { get; set; }
        public string Location { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventDate { get; set; }
        public string EventSponsor { get; set; }
        public string NewsImage { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<RegisterUserTable> Matches { get; set; }

        public RegisterUserTable()
        {
            Matches = new List<RegisterUserTable>();
        }

    }
    
}

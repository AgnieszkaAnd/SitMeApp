using System;
using System.Collections.Generic;

namespace DataAccessLibary.Models
{
    public class User
    {
        public static readonly string TableName = "[Client].[User]";
        public Guid Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNb { get; set; }

    }
}
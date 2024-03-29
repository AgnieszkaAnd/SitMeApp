﻿using DataAccessLibrary.Base;

namespace DataAccessLibrary.Models
{
    public class User : Domain
    {
        public static string TableName { get; } = "[Client].[User]";
        
        public string Nick { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string TelephoneNb { get; set; }
    }
}
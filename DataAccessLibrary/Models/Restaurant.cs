using System;
using System.Collections.Generic;
using DataAccessLibrary.Base;

namespace DataAccessLibrary.Models
{
    public class Restaurant : DomainBase
    {
        public static string TableName = "[Manager].[Restaurant]";

        public string Name { get; set; }
        
        public string City { get; set; }
        
        public string Address { get; set; }
        
        public string Description { get; set; }
        
        public string Telephone { get; set; }
        
        public string Email { get; set; }
        
        public string WebsiteLink { get; set; }
        
        public string MenuLink { get; set; }
        
        public TimeSpan OpeningTime { get; set; }
        
        public TimeSpan CloseTime { get; set; }
        
        // TODO remove list instance creation from the model
        // To be removed: new List<Tag>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
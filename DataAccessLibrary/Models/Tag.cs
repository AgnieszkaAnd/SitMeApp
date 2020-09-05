using System;
using System.Collections.Generic;
using DataAccessLibrary.Base;

namespace DataAccessLibrary.Models
{
    public class Tag : DomainBase
    {
        public static string TableName = "[Manager].[Tag]";

        public string Name { get; set; }
        
        public Guid TagGroupId { get; set; }
        
        // TODO: remove creating new list instance from the model
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}

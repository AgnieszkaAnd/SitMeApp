using System;
using System.Collections.Generic;
using DataAccessLibrary.Base;

namespace DataAccessLibrary.Models 
{
    public class Tag : Domain
    {
        public static string TableName = "[Manager].[Tag]";
        
        public string Name { get; set; }
        
        public Guid TagGroupId { get; set; }
        
        public List<Restaurant> Restaurants { get; set; }
    }
}

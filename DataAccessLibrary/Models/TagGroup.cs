using System;
using System.Collections.Generic;
using DataAccessLibrary.Base;

namespace DataAccessLibrary.Models
{
    public class TagGroup : Domain
    {
        public static string TableName = "[Manager].[TagGroup]";

        public string Name { get; set; }
        
        public List<Tag> Tags { get; set; }
    }
}

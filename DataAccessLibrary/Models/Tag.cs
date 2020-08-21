using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models {
    public class Tag {
        public static readonly string TableName = "[Manager].[Tag]";
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TagGroupId { get; set; }
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibary.Models {
    public class TagGroup {
        public static readonly string TableName = "[Manager].[TagGroup]";
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
    }
}

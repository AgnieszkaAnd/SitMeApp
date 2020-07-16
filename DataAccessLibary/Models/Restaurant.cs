using System;
using System.Collections.Generic;

namespace DataAccessLibary.Models
{
    public class Restaurant
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public HashSet Tags { get; set; }

        public Enum Pricing { get; set; }

        public List<Table> Tables { get; set; }

        public int ID { get; set; }

        public List<User> Managers { get; set; }

        public string Telephone { get; set; }

        public string MenuLink { get; set; }
    }
}
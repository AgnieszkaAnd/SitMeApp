using System;
using System.Collections.Generic;

namespace DataAccessLibary.Models
{
    public class Restaurant
    {
        public static readonly string TableName = "[Manager].[Restaurant]";
        public Guid Id { get; set; }
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

    }
}
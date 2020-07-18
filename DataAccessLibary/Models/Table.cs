using System;
using System.Collections.Generic;

namespace DataAccessLibary.Models
{
    public class Table
    {
        public static string TableName = "[Manager].[Table]";
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TableTypeId { get; set; }
        public byte MaxNbOfSeats { get; set; }
        public byte[] Picture { get; set; }
        public string LocationInRestaurant { get; set; }
        public bool IsVisibleForUsers { get; set; }
        public Guid RestaurantId { get; set; }

    }
}
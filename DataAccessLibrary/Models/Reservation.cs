using System;
using DataAccessLibrary.Base;

namespace DataAccessLibrary.Models
{
    public class Reservation : DomainBase
    {
        public static string TableName = "[Client].[Reservation]";

        public Guid UserId { get; set; }
        
        public DateTime StartDateTime { get; set; }
        
        public DateTime EndDateTime { get; set; }
        
        public byte NumberOfPeople { get; set; }
        
        public string CustomerSpecialRequest { get; set; }
        
        public bool IsConfirmed { get; set; }
        
        public bool CustomerArrived { get; set; }
    }
}
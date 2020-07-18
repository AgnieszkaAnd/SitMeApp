using System;

namespace DataAccessLibary.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public byte NbOfPeople { get; set; }
        public string CustomerSpecialRequest { get; set; }
        public bool IsConfirmed { get; set; }
        public bool CustomerArrived { get; set; }

    }
}
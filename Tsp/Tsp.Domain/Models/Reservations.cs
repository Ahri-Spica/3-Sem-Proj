using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Domain.Models
{
    public class Reservations
    {
        public int ReservationId { get; set; }
        // TODO Remove itemid as Rental already maps this.
        public int ItemId { get; set; }
        //public int CustomerId {get; set;}
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Rental Rental { get; set; }
        // public Customer Customer {get; set; }
        // TODO Create IReservationDomainService which handles the OverlappingCheck
    }
}

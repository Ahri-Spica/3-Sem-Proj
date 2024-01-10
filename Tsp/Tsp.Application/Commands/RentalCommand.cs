using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsp.Application.Dto_s;
using Tsp.Application.IQueries;
using Tsp.Domain.Models;

namespace Tsp.Application.Commands
{
    public class RentalCommand : IRentalCommand
    {
        // TODO Queries are meant for read requests and should not be used in internal logic. Use the IRentalRepository instead.
        private readonly IRentalStateQry rentalStateQry;

        public RentalCommand(IRentalStateQry _rentalStateQry) 
        {
            rentalStateQry = _rentalStateQry;
        }

        

       public async Task<Rental> RentItem(RentalWriteDTO rentalWriteDto)
        {
            // TODO Get the Rental from the IRentalRepository
            
            // TODO New the reservation domain object and let it handle validation, using the IReservationDomainService to check if overlapping.
            var reservation = new Reservations();
            // TODO Save the rental via IRentalRepository, EntityFramework throws an exception when you try to save an object with a mismatch on the concurrency token, hence a concrete check is not needed.
            
            var currentState = await rentalStateQry.CheckRentalState(new RentalStateDTO { RentalId = id, RowVersion = rowVersion });
            //check for concurrency drift, if so - abort
            if (!StateMatch(rowVersion, currentState.RowVersion))
            {
                throw new Exception("State of the item has changed");
            }
            //overlap algo

            //Reservationslist, if not present then dont check for overlap
            //if succes then save the reservation from the api
            throw new NotImplementedException();
        }

        private bool StateMatch(uint percievedState, uint realState)
        {
            return percievedState == realState;
        }
    }
}

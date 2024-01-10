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
        private readonly IRentalStateQry rentalStateQry;

        public RentalCommand(IRentalStateQry _rentalStateQry) 
        {
            rentalStateQry = _rentalStateQry;
        }

        

       public async Task<Rental> RentItem(Guid id, uint rowVersion)
        {
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

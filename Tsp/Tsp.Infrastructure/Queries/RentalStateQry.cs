using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsp.Application.Dto_s;
using Tsp.Application.IQueries;
using Tsp.Domain.Models;

namespace Tsp.Infrastructure.Queries
{
    public class RentalStateQry : IRentalStateQry
    {
        async Task<Rental> IRentalStateQry.CheckRentalState(RentalStateDTO rentalStateDTO)
        {
            //Implment me
            //return
        }
    }
}

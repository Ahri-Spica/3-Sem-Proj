using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsp.Application.Dto_s;
using Tsp.Domain.Models;

namespace Tsp.Application.IQueries
{
    public interface IRentalStateQry
    {
        Task<Rental> CheckRentalState(RentalStateDTO rentalStateDTO);
    }
}

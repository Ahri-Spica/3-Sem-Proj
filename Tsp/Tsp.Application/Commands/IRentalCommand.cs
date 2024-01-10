using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsp.Application.Dto_s;
using Tsp.Domain.Models;

namespace Tsp.Application.Commands
{
    public interface IRentalCommand
    {
        Task<Rental> RentItem(RentalWriteDTO rentalWriteDTO);
    }
}

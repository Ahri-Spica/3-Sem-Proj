using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Application.Dto_s
{
    public class RentalStateDTO
    {
        public Guid RentalId { get; set; }
        public uint RowVersion { get; set; }
    }
}

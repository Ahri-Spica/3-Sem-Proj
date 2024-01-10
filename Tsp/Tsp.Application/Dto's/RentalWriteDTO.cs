using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Application.Dto_s
{
    public class RentalWriteDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public uint RowVersion { get; set; }
    }
}

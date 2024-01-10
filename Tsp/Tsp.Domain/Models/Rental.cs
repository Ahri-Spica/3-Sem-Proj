using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Domain.Models
{
    public class Rental
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public bool IsRented { get; set; }
        [Timestamp]
        public uint RowVersion { get; set; }
    }
}

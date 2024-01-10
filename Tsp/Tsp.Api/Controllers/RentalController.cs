using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tsp.Application.Commands;
using Tsp.Application.Dto_s;

namespace Tsp.Api.Controllers
{
    public class RentalController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CtlrRentItem([FromBody] RentalStateDTO rstDTO)
        {
            try
            {
                var rentalCommand = new RentalCommand();
                var rental = await rentalCommand.RentItem(rstDTO.RentalId, rstDTO.RowVersion);
                return Ok(rental);
            }
            catch (DbUpdateConcurrencyException)
            {
                //handleit
            };
        }

        [HttpGet]
        public async Task<IActionResult> SeeRentItems(RentalReadDTO rentalReadDTO)
        {
            return null;
        }
    }
}

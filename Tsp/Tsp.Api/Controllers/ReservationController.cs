using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tsp.Application.Commands;
using Tsp.Application.Dto_s;

namespace Tsp.Api.Controllers
{
    public class ReservationController : Controller
    {
        [HttpPost]
        // TODO Create new Rent Item DTO
        public async Task<IActionResult> CtlrRentItem([FromBody] RentalWriteDTO rentalWriteDto)
        {
            try
            {
                // TODO Use dependency injection and not the concrete implementation, same way DocumentController injects IDocumentRepository
                IRentalCommand rentalCommand = new RentalCommand();
                // TODO Why extract to base values? Use the RentalStateDTO or create a new DTO to hold this requests information.
                var rental = await rentalCommand.RentItem(rentalWriteDto);
                return Ok(rental);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
                // TODO While this is the easy way to handle the concurrency exception, you should really consider a custom exception and have the command service throw that instead.
                // This creates a flow that is easier to handle and encapsulates the data better.
                //handleit
            };
        }

        [HttpGet]
        public async Task<IActionResult> SeeRentItems(RentalReadDTO rentalReadDTO)
        {
            return null;
        }
    }

    public class RentItemRequestDto
    {
    }
}

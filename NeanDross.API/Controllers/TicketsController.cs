using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeanDross.API.Data;
using NeanDros.Shared.Entities;


namespace NeanDros.API.Controllers
{
    [ApiController]
    [Route("/api/tickets")]
    public class TicketsController:ControllerBase 
    {
        private readonly DataContext _dataContext;

        public TicketsController(DataContext context)
        {
            _dataContext= context;
        }

        [HttpGet("totalPages")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dataContext.Tickets.CountAsync());
        }

        [HttpGet("ValidateTicket")]
        public async Task<IActionResult> GetAsyncValidate(int ticketId)
        {
            var ticket = await _dataContext.Tickets.FirstOrDefaultAsync(x => x.TicketId == ticketId);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetAsyncValidateStatus(int ticketId)
        {
            var ticket = await _dataContext.Tickets.FirstOrDefaultAsync(x => x.TicketId == ticketId);
            if (ticket!.TicketStatus)
            {
                return BadRequest(ticket);
            }
            else
            {
                return Ok();  
            }
    
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Ticket ticket)
        {
            try
            {
                _dataContext.Update(ticket);
                await _dataContext.SaveChangesAsync();
                return Ok(ticket);
            }
            catch (DbUpdateException)
            {
                    return BadRequest("Error al Registrar Ticket");
             }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketTrackerAPI.Models;

namespace TicketTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketmastersController : ControllerBase
    {
        private readonly TicketTrackerContext _context;

        public TicketmastersController(TicketTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Ticketmasters
        [HttpGet]
        public IEnumerable<Ticketmaster> GetTicketmaster()
        {
            return _context.Ticketmaster;
        }

        // GET: api/Ticketmasters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketmaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketmaster = await _context.Ticketmaster.FindAsync(id);

            if (ticketmaster == null)
            {
                return NotFound();
            }

            return Ok(ticketmaster);
        }

        // PUT: api/Ticketmasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketmaster([FromRoute] int id, [FromBody] Ticketmaster ticketmaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketmaster.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(ticketmaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketmasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ticketmasters
        [HttpPost]
        public async Task<IActionResult> PostTicketmaster([FromBody] Ticketmaster ticketmaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ticketmaster.Add(ticketmaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketmaster", new { id = ticketmaster.TicketId }, ticketmaster);
        }

        // DELETE: api/Ticketmasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketmaster([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketmaster = await _context.Ticketmaster.FindAsync(id);
            if (ticketmaster == null)
            {
                return NotFound();
            }

            _context.Ticketmaster.Remove(ticketmaster);
            await _context.SaveChangesAsync();

            return Ok(ticketmaster);
        }

        private bool TicketmasterExists(int id)
        {
            return _context.Ticketmaster.Any(e => e.TicketId == id);
        }
    }
}
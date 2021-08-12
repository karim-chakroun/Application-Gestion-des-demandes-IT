using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class requestsController : ControllerBase
    {
        private readonly requestsContext _context;

        public requestsController(requestsContext context)
        {
            _context = context;
        }

        // GET: api/requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<requests>>> Getrequests()
        {
            return await _context.requests.ToListAsync();
        }

        // GET: api/requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<requests>> Getrequests(int? id)
        {
            var requests = await _context.requests.FindAsync(id);

            //var requests = await _context.requests.Include(i => i.Comments).FirstOrDefaultAsync(i => i.RequestsId == id);

            if (requests == null)
            {
                return NotFound();
            }

            return requests;
        }

        // PUT: api/requests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrequests(int? id, requests requests)
        {
            if (id != requests.RequestsId)
            {
                return BadRequest();
            }

            _context.Entry(requests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!requestsExists(id))
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

        // POST: api/requests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<requests>> Postrequests(requests requests)
        {
            _context.requests.Add(requests);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrequests", new { id = requests.RequestsId }, requests);
        }

        // DELETE: api/requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<requests>> Deleterequests(int? id)
        {
            var requests = await _context.requests.FindAsync(id);
            if (requests == null)
            {
                return NotFound();
            }

            _context.requests.Remove(requests);
            await _context.SaveChangesAsync();

            return requests;
        }

        private bool requestsExists(int? id)
        {
            return _context.requests.Any(e => e.RequestsId == id);
        }
    }
}

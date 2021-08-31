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
    public class notificationsController : ControllerBase
    {
        private readonly requestsContext _context;

        public notificationsController(requestsContext context)
        {
            _context = context;
        }

        // GET: api/notifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<notification>>> Getnotification()
        {
            return await _context.notification.ToListAsync();
        }

        // GET: api/notifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<notification>> Getnotification(int? id)
        {
            var notification = await _context.notification.FindAsync(id);

            if (notification == null)
            {
                return NotFound();
            }

            return notification;
        }

        // PUT: api/notifications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnotification(int? id, notification notification)
        {
            if (id != notification.notifId)
            {
                return BadRequest();
            }

            _context.Entry(notification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!notificationExists(id))
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

        // POST: api/notifications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<notification>> Postnotification(notification notification)
        {
            _context.notification.Add(notification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnotification", new { id = notification.notifId }, notification);
        }

        // DELETE: api/notifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<notification>> Deletenotification(int? id)
        {
            var notification = await _context.notification.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            _context.notification.Remove(notification);
            await _context.SaveChangesAsync();

            return notification;
        }

        private bool notificationExists(int? id)
        {
            return _context.notification.Any(e => e.notifId == id);
        }
    }
}

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
    public class commentsController : ControllerBase
    {
        private readonly requestsContext _context;

        public commentsController(requestsContext context)
        {
            _context = context;
        }

        // GET: api/comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<comments>>> Getcomments()
        {
            return await _context.comments.ToListAsync();
        }

        // GET: api/comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<comments>> Getcomments(int? id)
        {
            var comments = await _context.comments.FindAsync(id);

            if (comments == null)
            {
                return NotFound();
            }

            return comments;
        }

        // PUT: api/comments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcomments(int? id, comments comments)
        {
            if (id != comments.commentId)
            {
                return BadRequest();
            }

            _context.Entry(comments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!commentsExists(id))
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

        // POST: api/comments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<comments>> Postcomments(comments comments)
        {
            _context.comments.Add(comments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcomments", new { id = comments.commentId }, comments);
        }

        // DELETE: api/comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<comments>> Deletecomments(int? id)
        {
            var comments = await _context.comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            _context.comments.Remove(comments);
            await _context.SaveChangesAsync();

            return comments;
        }

        private bool commentsExists(int? id)
        {
            return _context.comments.Any(e => e.commentId == id);
        }
    }
}

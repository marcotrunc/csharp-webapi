using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using csharp_webapi.Models;

namespace csharp_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly SingleActivityContext _context;

        public ActivitiesController(SingleActivityContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SingleActivity>>> GetListActivities()
        {
          if (_context.ListActivities == null)
          {
              return NotFound();
          }
            return await _context.ListActivities.ToListAsync();
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SingleActivity>> GetSingleActivity(long id)
        {
          if (_context.ListActivities == null)
          {
              return NotFound();
          }
            var singleActivity = await _context.ListActivities.FindAsync(id);

            if (singleActivity == null)
            {
                return NotFound();
            }

            return singleActivity;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSingleActivity(long id, SingleActivity singleActivity)
        {
            if (id != singleActivity.Id)
            {
                return BadRequest();
            }

            _context.Entry(singleActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SingleActivityExists(id))
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

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SingleActivity>> PostSingleActivity(SingleActivity singleActivity)
        {
          if (_context.ListActivities == null)
          {
              return Problem("Entity set 'SingleActivityContext.ListActivities'  is null.");
          }
            _context.ListActivities.Add(singleActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSingleActivity", new { id = singleActivity.Id }, singleActivity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSingleActivity(long id)
        {
            if (_context.ListActivities == null)
            {
                return NotFound();
            }
            var singleActivity = await _context.ListActivities.FindAsync(id);
            if (singleActivity == null)
            {
                return NotFound();
            }

            _context.ListActivities.Remove(singleActivity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SingleActivityExists(long id)
        {
            return (_context.ListActivities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

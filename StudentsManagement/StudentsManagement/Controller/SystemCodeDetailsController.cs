using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagamentShared.Models;
using StudentsManagement.Data;

namespace StudentsManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemCodeDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemCodeDetails
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<SystemCodeDetails>>> GetSystemCodeDetails()
        {
            return await _context.SystemCodeDetails.ToListAsync();
        }

        // GET: api/SystemCodeDetails/5
        [HttpGet("Single/{id}")]
        public async Task<ActionResult<SystemCodeDetails>> GetSystemCodeDetails(int id)
        {
            var systemCodeDetails = await _context.SystemCodeDetails.FindAsync(id);

            if (systemCodeDetails == null)
            {
                return NotFound();
            }

            return systemCodeDetails;
        }

        // PUT: api/SystemCodeDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutSystemCodeDetails(int id, SystemCodeDetails systemCodeDetails)
        {
            if (id != systemCodeDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemCodeDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemCodeDetailsExists(id))
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

        // POST: api/SystemCodeDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<SystemCodeDetails>> PostSystemCodeDetails(SystemCodeDetails systemCodeDetails)
        {
            _context.SystemCodeDetails.Add(systemCodeDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemCodeDetails", new { id = systemCodeDetails.Id }, systemCodeDetails);
        }

        // DELETE: api/SystemCodeDetails/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSystemCodeDetails(int id)
        {
            var systemCodeDetails = await _context.SystemCodeDetails.FindAsync(id);
            if (systemCodeDetails == null)
            {
                return NotFound();
            }

            _context.SystemCodeDetails.Remove(systemCodeDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemCodeDetailsExists(int id)
        {
            return _context.SystemCodeDetails.Any(e => e.Id == id);
        }
    }
}

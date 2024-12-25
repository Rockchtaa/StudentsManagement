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
    public class SystemeCodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SystemeCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemeCodes
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<SystemeCode>>> GetSystemeCodes()
        {
            return await _context.SystemeCodes.ToListAsync();
        }

        // GET: api/SystemeCodes/5
        [HttpGet("Single/{id}")]
        public async Task<ActionResult<SystemeCode>> GetSystemeCode(int id)
        {
            var systemeCode = await _context.SystemeCodes.FindAsync(id);

            if (systemeCode == null)
            {
                return NotFound();
            }

            return systemeCode;
        }

        // PUT: api/SystemeCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutSystemeCode(int id, SystemeCode systemeCode)
        {
            if (id != systemeCode.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemeCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemeCodeExists(id))
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

        // POST: api/SystemeCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<SystemeCode>> PostSystemeCode(SystemeCode systemeCode)
        {
            _context.SystemeCodes.Add(systemeCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemeCode", new { id = systemeCode.Id }, systemeCode);
        }

        // DELETE: api/SystemeCodes/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSystemeCode(int id)
        {
            var systemeCode = await _context.SystemeCodes.FindAsync(id);
            if (systemeCode == null)
            {
                return NotFound();
            }

            _context.SystemeCodes.Remove(systemeCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemeCodeExists(int id)
        {
            return _context.SystemeCodes.Any(e => e.Id == id);
        }
    }
}

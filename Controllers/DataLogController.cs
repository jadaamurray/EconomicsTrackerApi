using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EconomicsTrackerApi.Models;
using EconomicsTrackerApi.Databse;
using Microsoft.AspNetCore.Authorization;


namespace EconomicsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataLogController : ControllerBase
    {
        private readonly EconomicsTrackerContext _context;

        public DataLogController(EconomicsTrackerContext context)
        {
            _context = context;
        }

        // GET: api/DataLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataLog>>> GetDataLog()
        {
            return await _context.DataLog.ToListAsync();
        }

        // GET: api/DataLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataLog>> GetDataLog(string id)
        {
            var dataLog = await _context.DataLog.FindAsync(id);

            if (dataLog == null)
            {
                return NotFound();
            }

            return dataLog;
        }

        // PUT: api/DataLog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataLog(string id, DataLog dataLog)
        {
            if (id != dataLog.DataLogId)
            {
                return BadRequest();
            }

            _context.Entry(dataLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataLogExists(id))
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

        // POST: api/DataLog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataLog>> PostDataLog(DataLog dataLog)
        {
            _context.DataLog.Add(dataLog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DataLogExists(dataLog.DataLogId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDataLog", new { id = dataLog.DataLogId }, dataLog);
        }

        // DELETE: api/DataLog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataLog(string id)
        {
            var dataLog = await _context.DataLog.FindAsync(id);
            if (dataLog == null)
            {
                return NotFound();
            }

            _context.DataLog.Remove(dataLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataLogExists(string id)
        {
            return _context.DataLog.Any(e => e.DataLogId == id);
        }
    }
}

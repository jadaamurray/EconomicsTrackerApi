using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EconomicsTrackerApi.Models;

namespace EconomicsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorController : ControllerBase
    {
        private readonly EconomicsTrackerContext _context;

        public IndicatorController(EconomicsTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Indicator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Indicator>>> GetIndicators()
        {
            return await _context.Indicators.ToListAsync();
        }

        // GET: api/Indicator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Indicator>> GetIndicator(string id)
        {
            var indicator = await _context.Indicators.FindAsync(id);

            if (indicator == null)
            {
                return NotFound();
            }

            return indicator;
        }

        // PUT: api/Indicator/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndicator(string id, Indicator indicator)
        {
            if (id != indicator.IndicatorId)
            {
                return BadRequest();
            }

            _context.Entry(indicator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndicatorExists(id))
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

        // POST: api/Indicator
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Indicator>> PostIndicator(Indicator indicator)
        {
            _context.Indicators.Add(indicator);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IndicatorExists(indicator.IndicatorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIndicator", new { id = indicator.IndicatorId }, indicator);
        }

        // DELETE: api/Indicator/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndicator(string id)
        {
            var indicator = await _context.Indicators.FindAsync(id);
            if (indicator == null)
            {
                return NotFound();
            }

            _context.Indicators.Remove(indicator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IndicatorExists(string id)
        {
            return _context.Indicators.Any(e => e.IndicatorId == id);
        }
    }
}

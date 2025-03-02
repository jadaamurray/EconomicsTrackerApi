using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EconomicsTrackerApi.Models;
using EconomicsTrackerApi.Database;
using Microsoft.AspNetCore.Authorization;


namespace EconomicsTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorController : ControllerBase
    {
        private readonly IIndicatorService _indicatorService;
        private readonly ILogger<IndicatorController> _logger;

        public IndicatorController(IIndicatorService indicatorService, ILogger<IndicatorController> logger)
        {
            _indicatorService = indicatorService;
            _logger = logger;
        }
        // GET: api/Indicator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Indicator>>> GetIndicators()
        {
            try
            {
                _logger.LogInformation("Fetching all indicators.");
                var indicators = await _indicatorService.GetAllIndicatorsAsync();
                if (indicators == null || !indicators.Any())
                {
                    _logger.LogWarning("No indicators found.");
                    return NotFound("No indicators found.");
                }
                return Ok(indicators);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching indicators.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/Indicator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Indicator>> GetIndicator(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching indicator with ID {id}");
                var indicator = await _indicatorService.GetIndicatorByIdAsync(id);

                if (indicator == null)
                {
                    _logger.LogWarning($"Indicator with ID {id} not found.");
                    return NotFound($"Indicator with ID {id} not found.");
                }

                return Ok(indicator);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the indicator.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Indicator/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndicator(int id, Indicator indicator)
        {
            try
            {
                if (id != indicator.IndicatorId)
                {
                    _logger.LogWarning("Indicator ID mismatch.");
                    return BadRequest("Indicator ID mismatch.");
                }

                await _indicatorService.UpdateIndicatorAsync(id, indicator);
                _logger.LogInformation($"Indicator with ID {id} updated.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _indicatorService.GetIndicatorByIdAsync(id) == null)
                {
                    _logger.LogWarning($"Indicator with ID {id} not found for update.");
                    return NotFound($"Indicator with ID {id} not found.");
                }
                else
                {
                    _logger.LogError("Error updating indicator.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the indicator.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/Indicator
        [HttpPost]
        public async Task<ActionResult<Indicator>> PostIndicator(Indicator indicator)
        {
            try
            {
                if (indicator == null)
                {
                    _logger.LogWarning("Received empty indicator object.");
                    return BadRequest("Indicator data cannot be null.");
                }

                await _indicatorService.AddIndicatorAsync(indicator);
                _logger.LogInformation($"Indicator with ID {indicator.IndicatorId} created.");
                return CreatedAtAction("GetIndicator", new { id = indicator.IndicatorId }, indicator);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the indicator.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Indicator/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndicator(int id)
        {
            try
            {
                var indicator = await _indicatorService.GetIndicatorByIdAsync(id);
                if (indicator == null)
                {
                    _logger.LogWarning($"Indicator with ID {id} not found.");
                    return NotFound($"Indicator with ID {id} not found.");
                }

                await _indicatorService.DeleteIndicatorAsync(id);
                _logger.LogInformation($"Indicator with ID {id} deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the indicator.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
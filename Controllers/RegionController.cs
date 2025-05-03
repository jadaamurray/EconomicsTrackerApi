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
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly ILogger<RegionController> _logger;

        public RegionController(IRegionService regionService, ILogger<RegionController> logger)
        {
            _regionService = regionService;
            _logger = logger;
        }

        // GET: api/Region
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            try
            {
                _logger.LogInformation("Fetching all regions.");
                var regions = await _regionService.GetAllRegionsAsync();
                if (regions == null || !regions.Any())
                {
                    _logger.LogWarning("No regions found.");
                    return NotFound("No regions found.");
                }
                return Ok(regions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching regions.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/Region/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching region with ID {id}");
                var region = await _regionService.GetRegionByIdAsync(id);

                if (region == null)
                {
                    _logger.LogWarning($"Region with ID {id} not found.");
                    return NotFound($"Region with ID {id} not found.");
                }

                return Ok(region);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the region.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Region/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            try
            {
                if (id != region.RegionId)
                {
                    _logger.LogWarning("Region ID mismatch.");
                    return BadRequest("Region ID mismatch.");
                }

                await _regionService.UpdateRegionAsync(id, region);
                _logger.LogInformation($"Region with ID {id} updated.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _regionService.GetRegionByIdAsync(id) == null)
                {
                    _logger.LogWarning($"Region with ID {id} not found for update.");
                    return NotFound($"Region with ID {id} not found.");
                }
                else
                {
                    _logger.LogError("Error updating region.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the region.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/Region
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            try
            {
                if (region == null)
                {
                    _logger.LogWarning("Received empty region object.");
                    return BadRequest("Region data cannot be null.");
                }

                await _regionService.AddRegionAsync(region);
                _logger.LogInformation($"Region with ID {region.RegionId} created.");
                return CreatedAtAction("GetRegion", new { id = region.RegionId }, region);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the region.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Region/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            try
            {
                var region = await _regionService.GetRegionByIdAsync(id);
                if (region == null)
                {
                    _logger.LogWarning($"Region with ID {id} not found.");
                    return NotFound($"Region with ID {id} not found.");
                }

                await _regionService.DeleteRegionAsync(id);
                _logger.LogInformation($"Region with ID {id} deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the region.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}



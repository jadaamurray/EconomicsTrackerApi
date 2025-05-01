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
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly ILogger<DataController> _logger;

        public DataController(IDataService dataService, ILogger<DataController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        // GET: api/Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Data>>> GetData()
        {
            try
            {
                _logger.LogInformation("Fetching all data.");
                var data = await _dataService.GetAllDataAsync();
                if (data == null || !data.Any())
                {
                    _logger.LogWarning("No data found.");
                    return NotFound("No data found.");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching economic data.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Data>> GetDataPoint(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching data point with ID {id}");
                var data = await _dataService.GetDataByIdAsync(id);

                if (data == null)
                {
                    _logger.LogWarning($"Data point with ID {id} not found.");
                    return NotFound($"Data point with ID {id} not found.");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the data point.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Data/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutData(int id, Data data)
        {
            try
            {
                if (id != data.DataId)
                {
                    _logger.LogWarning("Data point ID mismatch.");
                    return BadRequest("Data point ID mismatch.");
                }

                await _dataService.UpdateDataAsync(id, data);
                _logger.LogInformation($"Data point with ID {id} updated.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _dataService.GetDataByIdAsync(id) == null)
                {
                    _logger.LogWarning($"Data point with ID {id} not found for update.");
                    return NotFound($"Data point with ID {id} not found.");
                }
                else
                {
                    _logger.LogError("Error updating data point.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the data point.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/Data
        [HttpPost]
        public async Task<ActionResult<Data>> PostData(Data data)
        {
            try
            {
                if (data == null)
                {
                    _logger.LogWarning("Received empty data object.");
                    return BadRequest("Data point cannot be null.");
                }

                await _dataService.AddDataAsync(data);
                _logger.LogInformation($"Data point with ID {data.DataId} created.");
                return CreatedAtAction("GetDataPoint", new { id = data.DataId }, data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the data point.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            try
            {
                var data = await _dataService.GetDataByIdAsync(id);
                if (data == null)
                {
                    _logger.LogWarning($"Data point with ID {id} not found.");
                    return NotFound($"Data point with ID {id} not found.");
                }

                await _dataService.DeleteDataAsync(id);
                _logger.LogInformation($"Data point with ID {id} deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the data point.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}

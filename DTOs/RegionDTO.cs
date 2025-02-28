using System.ComponentModel.DataAnnotations;
using EconomicsTrackerApi.Models;

namespace EconomicsTrackerApi.DTOs
{
    public class RegionDTO
    {
        public int RegionId { get; set; }
        [StringLength(200, MinimumLength = 3)]
        public required string RegionName { get; set; }
        [StringLength(450, MinimumLength = 3)]
        public required string Description { get; set; }
        public List<Data>? RegionDataPoints { get; set; }
    }
}
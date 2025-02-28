using System.ComponentModel.DataAnnotations;
using EconomicsTrackerApi.Models;

namespace EconomicsTrackerApi.DTOs
{
    public class SourceDTO
    {
        public int SourceId { get; set; }
        [StringLength(450, MinimumLength = 3)]
        public required string Name { get; set; }
        public required string Url { get; set; }
        [StringLength(450, MinimumLength = 3)]
        public string? Description { get; set; }
        public required List<Data> SourceDataPoints { get; set; }
    }
}
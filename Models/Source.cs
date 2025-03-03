using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EconomicsTrackerApi.Models
{
    public class Source
    {
        public int SourceId { get; set; }
        [StringLength(450, MinimumLength = 3)]
        public required string Name { get; set; }
        public required string Url { get; set; }
        [StringLength(450, MinimumLength = 3)]
        public string? Description { get; set; } // nullable

        [JsonIgnore]
        public List<Data>? SourceDataPoints { get; set; } // nullable as we need the source to exist in the database before is a data point is added
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EconomicsTrackerApi.Models
{
    public class Source
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment ID
        public int SourceId { get; set; }
        [StringLength(450, MinimumLength = 3)]
        public required string Name { get; set; }
        public required string Url { get; set; }
        [StringLength(450, MinimumLength = 3)]
        public string? Description { get; set; } // nullable

        [JsonIgnore]
        public required List<Data> SourceDataPoints { get; set; } // not nullable as a source has to have at least one data point associated with it to be in the database
    }
}
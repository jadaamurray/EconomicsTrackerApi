using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EconomicsTrackerApi.Models
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment ID
        public int RegionId { get; set; }
        [StringLength(200, MinimumLength = 3)]
        public required string RegionName { get; set; }
        [StringLength(450, MinimumLength = 3)]
        public required string Description { get; set; }

        [JsonIgnore]
        public List<Data>? RegionDataPoints { get; set; } // nullable as a region can have 0 or many economic data points associated with it
    }
}
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EconomicsTrackerApi.Models
{
    public class Indicator
    {
        public int IndicatorId { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public required string IndicatorName { get; set; }
        public required string Unit { get; set; }
        [StringLength(450, MinimumLength = 3)]
        public string? Description { get; set; } // description and category are nullable attributes
        [StringLength(100, MinimumLength = 3)]
        public string? Category { get; set; }

        [JsonIgnore]
        public List<Data>? Values { get; set; } // nullable as the indicator may not have any data entries associated with it
    }
}
using System.Text.Json.Serialization; //
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // to access lists

namespace EconomicsTrackerApi.Models
{
    public class Data
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment ID
        public int DataId { get; set; }
        public DateTime DateTime { get; set; }
        public double Value { get; set; }

        // foreign keys from EconomicIndicator, Region, and Source tables
        public int IndicatorId { get; set; }
        public int SourceId { get; set; }
        public int RegionId { get; set; }

        // One-to-many relationship. We can easily access associated DataLog entries for admin purposes (e.g. history of who has accessed specific data points)
        [JsonIgnore]
        public List<DataLog>? DataLogs { get; set; } // optional as nobody might have accessed this data entry

    }
}

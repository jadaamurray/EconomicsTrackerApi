using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EconomicsTrackerApi.Models;

public class Indicator {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment ID
    public int IndicatorId {get; set;}
    public string IndicatorName {get; set;}
    public string Unit {get; set;}
    public string? Description {get; set;} // description and category are nullable attributes
    public string? Category {get; set;}

    [JsonIgnore]
    public List<Data>? Values {get; set;} // nullable as the indicator may not have any data entries associated with it
}
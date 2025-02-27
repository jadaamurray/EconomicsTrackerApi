using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EconomicsTrackerApi.Models;
public class Source {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment ID
    public int SourceId {get; set;}
    public string Name {get; set;}
    public string Url {get; set;}
    public string? Description {get; set;} // nullable

    [JsonIgnore]
    public List<Data> SourceDataPoints {get; set;} // not nullable as a source has to have at least one data point associated with it to be in the database
}
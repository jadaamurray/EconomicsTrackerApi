using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace EconomicsTrackerApi.Models;
public class Region {
    public string RegionId {get; set;}
    public string RegionName {get; set;}
    public string Description {get; set;}

    [JsonIgnore]
    public List<Data>? RegionDataPoints {get; set;} // nullable as a region can have 0 or many economic data points associated with it
}
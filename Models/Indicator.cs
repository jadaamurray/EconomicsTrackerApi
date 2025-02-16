namespace EconomicsTrackerApi.Models;

public class Indicator {
    public string IndicatorId {get; set;}
    public string IndicatorName {get; set;}
    public string Unit {get; set;}
    public string? Description {get; set;} // description and category are nullable attributes
    public string? Category {get; set;}

    public List<Data>? Values {get; set;} // nullable as the indicator may not have any data entries associated with it
}
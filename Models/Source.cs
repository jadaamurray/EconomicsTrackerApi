namespace EconomicsTrackerApi.Models;
public class Source {
    public string SourceId {get; set;}
    public string Name {get; set;}
    public string Url {get; set;}
    public string? Description {get; set;} // nullable

    public List<Data> SourceDataPoints {get; set;} // not nullable as a source has to have at least one data point associated with it to be in the database
}
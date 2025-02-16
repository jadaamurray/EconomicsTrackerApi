using System.Collections.Generic; // to access lists
namespace EconomicsTrackerApi.Models; // stopping naming conflicts
public class Data {
    public string DataId {get; set;}
    public DateTime DateTime {get; set;}
    public double Value {get; set;}

    // foreign keys from EconomicIndicator, Region, and Source tables
    public string IndicatorId {get; set;}
    public string SourceId {get; set;}
    public string RegionId {get; set;}

    // One-to-many relationship. We can easily access associated DataLog entries for admin purposes (e.g. history of who has accessed specific data points)
    public List<DataLog>? DataLogs { get; set; } // optional as nobody might have accessed this data entry

}

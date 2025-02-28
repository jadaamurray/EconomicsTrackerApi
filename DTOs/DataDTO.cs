using System.ComponentModel.DataAnnotations;

namespace EconomicsTrackerApi.DTOs;
    public class DataDTO
{
    public int DataId { get; set; }
    public DateTime DateTime { get; set; }
    public double Value { get; set; }


    public int IndicatorId { get; set; }
    public int SourceId { get; set; }
    public int RegionId { get; set; }
}

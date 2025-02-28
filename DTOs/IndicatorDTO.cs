using System.ComponentModel.DataAnnotations;
namespace EconomicsTrackerApi.DTOs;
using EconomicsTrackerApi.Models;
public class IndicatorDTO
{
    public int IndicatorId {get; set;}
    [StringLength(100, MinimumLength = 2)]
    public required string IndicatorName {get; set;}
    public required string Unit {get; set;}
    [StringLength(450, MinimumLength = 3)]
    public string? Description {get; set;}
    [StringLength(100, MinimumLength = 3)]
    public string? Category {get; set;}
    public List<Data>? Values {get; set;} 
}
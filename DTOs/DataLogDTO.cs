using System.ComponentModel.DataAnnotations;
using EconomicsTrackerApi.Models;

namespace EconomicsTrackerApi.DTOs;

public class DataLogDTO
{
public int DataLogId {get; set;}
    public DateTime DateTimeAccessed {get; set;}
    public int DataId {get; set;}
    public required string UserId {get; set;}

    public Data? Data {get; set;}
}
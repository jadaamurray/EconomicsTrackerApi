using System.Collections.Generic;
using System.Text.Json.Serialization; // to access lists
namespace EconomicsTrackerApi.Models; // stopping naming conflicts 
public class User {
    public string UserId {get; set;}
    public string Username {get; set;}
    public string Role {get; set;}


    // One-to-many relationship. We can easily access associated DataLog entries for admin purposes (e.g. history of who has accessed specific data points)
    [JsonIgnore]
    public List<DataLog>? DataLogs { get; set; } // nullable as a user might not have accessed any data points
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace EconomicsTrackerApi.Models; // stopping naming conflicts

// link table due to many to many relationship between EconomicData and User
public class DataLog {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment ID
    public int DataLogId {get; set;}
    public DateTime DateTimeAccessed {get; set;}
    // foreign keys from EconomicData and User tables
    public int DataId {get; set;}
    public string UserId {get; set;}

    // Inlcuding data and user objects to be able to easily navigate to related entities when querying the database. Nullable as no users might have accessed any data yet
    [JsonIgnore]
    public Data? Data {get; set;}
}
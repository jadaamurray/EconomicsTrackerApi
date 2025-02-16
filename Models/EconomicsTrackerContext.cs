using Microsoft.EntityFrameworkCore;

namespace EconomicsTrackerApi.Models;
public class EconomicsTrackerContext : DbContext // Inheriting from DbContext, a core class in Entity Framework Core
{
    public EconomicsTrackerContext(DbContextOptions<EconomicsTrackerContext> options) : base(options) {} // Constructor

    // Adding DbSets, determining the tables in the database
    public DbSet<DataLog> DataLog {get; set;}
    public DbSet<Data> Data {get; set;}
    public DbSet<Indicator> Indicators {get; set;}
    public DbSet<Region> Regions {get; set;}
    public DbSet<Source> Sources {get; set;}

    public DbSet<User> Users {get; set;}

}
using Microsoft.EntityFrameworkCore;
using EconomicsTrackerApi.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace EconomicsTrackerApi.Database;
public class EconomicsTrackerContext : IdentityDbContext<ApplicationUser> // Inheriting from DbContext, a core class in Entity Framework Core
{
    public EconomicsTrackerContext(DbContextOptions<EconomicsTrackerContext> options) : base(options) { } // Constructor

    // Adding DbSets, determining the tables in the database
    public DbSet<DataLog> DataLog { get; set; }
    public DbSet<Data> Data { get; set; }
    public DbSet<Indicator> Indicators { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Source> Sources { get; set; }

    // add DbSet for favourites later
    // public DbSet<Favorite> Favorites { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Only configure if not already configured (for DI compatibility)
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=EconomicsTracker.db;Foreign Keys=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure all entities with int primary keys to auto-increment
    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
        var primaryKey = entityType.FindPrimaryKey();
        if (primaryKey != null && primaryKey.Properties.Count == 1)
        {
            var property = primaryKey.Properties[0];
            if (property.ClrType == typeof(int))
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
                property.SetColumnType("INTEGER"); // Ensures auto-increment behavior
            }
        }
    }
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Source>(entity =>
        {
            entity.Property(e => e.SourceId)
                  .ValueGeneratedOnAdd(); // Explicitly configure SQLite auto-increment
        });
    }
}
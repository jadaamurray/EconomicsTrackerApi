using Microsoft.EntityFrameworkCore;
using EconomicsTrackerApi.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EconomicsTrackerApi.Databse;
public class EconomicsTrackerContext : IdentityDbContext<IdentityUser> // Inheriting from DbContext, a core class in Entity Framework Core
{
    public EconomicsTrackerContext(DbContextOptions<EconomicsTrackerContext> options) : base(options) {} // Constructor

    // Adding DbSets, determining the tables in the database
    public DbSet<DataLog> DataLog {get; set;}
    public DbSet<Data> Data {get; set;}
    public DbSet<Indicator> Indicators {get; set;}
    public DbSet<Region> Regions {get; set;}
    public DbSet<Source> Sources {get; set;}
}
using Microsoft.EntityFrameworkCore;
using ClinicalTrialsAPI.Models;
namespace ClinicalTrialsAPI.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<ClinicalTrial> ClinicalTrials { get; set; }
}
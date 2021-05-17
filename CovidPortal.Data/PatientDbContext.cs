using CovidPortal.Data.Configurations;
using CovidPortal.Data.Extensions;
using CovidPortal.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CovidPortal.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new PatientConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Patient> Patients { get; set; }
    }
}

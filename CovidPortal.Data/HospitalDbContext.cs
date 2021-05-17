using CovidPortal.Data.Configurations;
using CovidPortal.Data.Extensions;
using CovidPortal.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CovidPortal.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new HospitalConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Hospital> Hospitals { get; set; }
    }
}

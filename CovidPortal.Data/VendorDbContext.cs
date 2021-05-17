using CovidPortal.Data.Configurations;
using CovidPortal.Data.Extensions;
using CovidPortal.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CovidPortal.Data
{
    public class VendorDbContext : DbContext
    {
        public VendorDbContext(DbContextOptions<VendorDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new VendorConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vendor> Vendors { get; set; }
    }
}

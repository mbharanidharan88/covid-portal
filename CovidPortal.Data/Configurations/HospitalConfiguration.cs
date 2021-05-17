using CovidPortal.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CovidPortal.Data.Configurations
{
    internal class HospitalConfiguration : BaseEntityConfiguration<Hospital>
    {
        public override void Configure(EntityTypeBuilder<Hospital> entity)
        {
            entity.ToTable("Hospital");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.ApplicationUserId).IsRequired();
            entity.Property(c => c.HospitalName).IsRequired();
            entity.Property(c => c.HospitalCity).IsRequired();
            entity.Property(c => c.NumberOfBeds).IsRequired();
            entity.Property(c => c.OxygenCapacityInTonnes).IsRequired();
            entity.Property(c => c.BalanceCapacityInTonnes).IsRequired();
        }
    }
}

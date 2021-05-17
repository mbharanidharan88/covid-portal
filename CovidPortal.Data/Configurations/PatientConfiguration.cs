using CovidPortal.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidPortal.Data.Configurations
{
    internal class PatientConfiguration : BaseEntityConfiguration<Patient>
    {
        public override void Configure(EntityTypeBuilder<Patient> entity)
        {
            entity.ToTable("Patient");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.ApplicationUserId).IsRequired();
            entity.Property(c => c.PatientName).IsRequired();
            entity.Property(c => c.CovidTestedDate).IsRequired();
            entity.Property(c => c.HealthComplications).IsRequired();
            entity.Property(c => c.DaysInQueue).IsRequired();
            entity.Property(c => c.Email).IsRequired();
            entity.Property(c => c.Mobile).IsRequired();
            //entity.HasOne(c => c.User);
        }
    }
}

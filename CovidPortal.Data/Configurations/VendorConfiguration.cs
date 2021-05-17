using CovidPortal.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CovidPortal.Data.Configurations
{
    internal class VendorConfiguration : BaseEntityConfiguration<Vendor>
    {
        public override void Configure(EntityTypeBuilder<Vendor> entity)
        {
            entity.ToTable("Vendor");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.ApplicationUserId).IsRequired();
            entity.Property(c => c.VendorName).IsRequired();
            entity.Property(c => c.VendorCity).IsRequired();
            entity.Property(c => c.Product).IsRequired();
            entity.Property(c => c.Email).IsRequired();
            entity.Property(c => c.Mobile).IsRequired();
        }
    }
}

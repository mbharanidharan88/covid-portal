using CovidPortal.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidPortal.Data.Configurations
{
    internal abstract class BaseEntityConfiguration<TEntity> where TEntity : BaseEntity
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}

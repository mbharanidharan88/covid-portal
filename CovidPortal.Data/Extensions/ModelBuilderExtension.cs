using CovidPortal.Data.Configurations;
using CovidPortal.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace CovidPortal.Data.Extensions
{
    internal static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(
          this ModelBuilder modelBuilder,
          BaseEntityConfiguration<TEntity> entityConfiguration) where TEntity : BaseEntity
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
        }
    }
}

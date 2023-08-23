using FullstackAfiliados.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullstackAfiliados.Infra.Data.Data.Configurations.Base;

public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.CreateAt)
            .HasDefaultValueSql("now()")
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
    }
}

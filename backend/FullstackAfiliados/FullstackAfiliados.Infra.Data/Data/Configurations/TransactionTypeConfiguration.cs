using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Infra.Data.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullstackAfiliados.Infra.Data.Data.Configurations;

public class TransactionTypeConfiguration: EntityConfiguration<TransactionType>
{
    public override void Configure(EntityTypeBuilder<TransactionType> builder)
    {
        base.Configure(builder);

        builder.ToTable("TransactionTypes");

        builder.Property(p => p.Type).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Origin).IsRequired();
        builder.Property(p => p.Signal).IsRequired();
    }
}
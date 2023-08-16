using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Infra.Data.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullstackAfiliados.Infra.Data.Data.Configurations;

public class TransactionConfiguration: EntityConfiguration<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);

        builder.ToTable("Transactions");

        builder.HasOne(p => p.Type)
            .WithMany()
            .HasForeignKey(p => p.TypeId)
            .IsRequired();

        builder.Property(p => p.Date).IsRequired();

        builder.Property(p => p.Product)
            .HasColumnType("varchar(30)")
            .IsRequired();

        builder.Property(p => p.Amount).IsRequired();

        builder.Property(p => p.Salesman)
            .HasColumnType("varchar(20)")
            .IsRequired();
    }
}
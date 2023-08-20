using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FullstackAfiliados.Infra.Data.Data;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionStringBuilder = new NpgsqlConnectionStringBuilder
        {
            Host = Environment.GetEnvironmentVariable("DATABASE_HOST"),
            Port = int.Parse(Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432"),
            Database = Environment.GetEnvironmentVariable("DATABASE_DEFAULT") ?? "FullstackAfiliados",
            Username = Environment.GetEnvironmentVariable("DATABASE_USER"),
            Password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD")
        };
        options.UseNpgsql(connectionStringBuilder.ToString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Model.GetEntityTypes().ToList().ForEach(entityType =>
        {
            entityType.SetTableName(entityType.DisplayName());

            entityType.GetForeignKeys()
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);

            entityType.GetProperties()
                .Where(p => p.ClrType == typeof(string))
                .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name))
                .ToList()
                .ForEach(property =>
                {
                    property.IsUnicode(false);
                    property.HasMaxLength(DefaultValues.VarcharLenght);
                });
        });

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultValues).Assembly);
    }
}
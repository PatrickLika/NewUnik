using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Domain.Projekt.Model;

namespace Unik.SqlServerContext.Projekt;

public class SalesTypeConfiguration : IEntityTypeConfiguration<ProjektEntity>
{
    public void Configure(EntityTypeBuilder<ProjektEntity> builder)
    {
        builder.ToTable("Projekt", "projekt");

        builder.HasKey(x => x.Id);
    }
}
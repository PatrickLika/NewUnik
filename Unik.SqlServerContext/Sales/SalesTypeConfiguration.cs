using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Domain.Sales.Model;

namespace Unik.SqlServerContext.Sales;

public class SalesTypeConfiguration : IEntityTypeConfiguration<SalesEntity>
{
    public void Configure(EntityTypeBuilder<SalesEntity> builder)
    {
        builder.ToTable("Sales", "sales");

        builder.HasKey(x => x.Id);
    }
}
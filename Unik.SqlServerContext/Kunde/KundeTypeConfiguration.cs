using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Domain.Kunde.Model;
using Unik.Domain.Projekt.Model;

namespace Unik.SqlServerContext.Kunde
{
    public class KundeTypeConfiguration : IEntityTypeConfiguration<KundeEntity>
    {
        public void Configure(EntityTypeBuilder<KundeEntity> builder)
        {
            builder.ToTable("Kunde", "kunde");

            builder.HasKey(x => x.Id);
        }
    }
}

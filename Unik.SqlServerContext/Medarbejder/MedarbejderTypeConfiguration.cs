using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Domain.Medarbejder.Model;

namespace Unik.SqlServerContext.Medarbejder
{
    public class MedarbejderTypeConfiguration : IEntityTypeConfiguration<MedarbejderEntity>
    {
        public void Configure(EntityTypeBuilder<MedarbejderEntity> builder)
        {
            builder.ToTable("Medarbejder", "medarbejder");

            builder.HasKey(x => x.Id);
        }
    }
}

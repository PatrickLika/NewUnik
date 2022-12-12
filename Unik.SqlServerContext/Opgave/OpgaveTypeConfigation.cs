using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Domain.Opgave.Model;

namespace Unik.SqlServerContext.Opgave
{
    public class OpgaveTypeConfigation : IEntityTypeConfiguration<OpgaveEntity>
    {
        public void Configure(EntityTypeBuilder<OpgaveEntity> builder)
        {
            builder.ToTable("Opgave", "opgave");

            builder.HasKey(x => x.Id);
        }
    }
}

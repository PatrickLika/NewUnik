using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Domain.Booking.Model;

namespace Unik.SqlServerContext.Booking;

public class BookingTypeConfiguration : IEntityTypeConfiguration<BookingEntity>
{
    public void Configure(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.ToTable("Booking", "booking");
        builder.HasKey(x => x.Id);
    }
}
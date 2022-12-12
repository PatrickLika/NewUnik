using Unik.Domain.Booking.Model;

namespace Unik.Domain.Booking.DomainServices
{
    public interface IBookingDomainService
    {
        IEnumerable<BookingEntity> GetBookings(int medarbejderId);
    }
}

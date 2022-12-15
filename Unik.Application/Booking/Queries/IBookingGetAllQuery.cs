using Unik.Application.Booking.Queries;

namespace Unik.Applicaiton.Booking.Queries
{
    public interface IBookingGetAllQuery
    {
        IEnumerable<BookingGetAllResulstDto> GetAll();
    }
}

using Unik.Application.Booking.Queries.Implementation;

namespace Unik.Applicaiton.Booking.Queries
{
    public interface IBookingGetAllQuery
    {
        IEnumerable<BookingGetAllResulstDto> GetAll();
    }
}

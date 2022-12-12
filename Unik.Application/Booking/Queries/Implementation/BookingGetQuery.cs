using Unik.Applicaiton.Booking.Repositories;

namespace Unik.Applicaiton.Booking.Queries.Implementation;

public class BookingGetQuery : IBookingGetQuery
{
    private readonly IBookingRepository _bookingRepository;

    public BookingGetQuery(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    BookingResultDto IBookingGetQuery.Get(int bookingId)
    {
        return _bookingRepository.Get(bookingId);
    }
}
using Unik.Applicaiton.Booking.Repositories;

namespace Unik.Applicaiton.Booking.Queries.Implementation
{
    public class BookingGetAllQuery : IBookingGetAllQuery
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingGetAllQuery(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        IEnumerable<BookingResultDto> IBookingGetAllQuery.GetAll()
        {
            return _bookingRepository.GetAll();
        }
    }
}

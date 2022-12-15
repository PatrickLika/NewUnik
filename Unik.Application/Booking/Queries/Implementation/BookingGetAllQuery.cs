using Unik.Applicaiton.Booking.Repositories;
using Unik.Application.Booking.Queries;

namespace Unik.Applicaiton.Booking.Queries.Implementation
{
    public class BookingGetAllQuery : IBookingGetAllQuery
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingGetAllQuery(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        IEnumerable<BookingGetAllResulstDto> IBookingGetAllQuery.GetAll()
        {
            return _bookingRepository.GetAll();
        }
    }
}

using Unik.Applicaiton.Booking.Repositories;

namespace Unik.Applicaiton.Booking.Queries.Implementation
{
    public class FindMedarbejder : IFindMedarbejder
    {
        private readonly IBookingRepository _bookingRepository;

        public FindMedarbejder(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        IEnumerable<FindMedarbejderDto> IFindMedarbejder.FindMedarbejder(string type)
        {
            return _bookingRepository.FindMedarbejder(type);
        }
    }
}

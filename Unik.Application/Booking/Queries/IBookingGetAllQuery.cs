namespace Unik.Applicaiton.Booking.Queries
{
    public interface IBookingGetAllQuery
    {
        IEnumerable<BookingResultDto> GetAll();
    }
}

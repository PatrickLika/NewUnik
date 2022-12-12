namespace Unik.Applicaiton.Booking.Queries;

public interface IBookingGetQuery
{
    BookingResultDto Get(int bookingId);
}
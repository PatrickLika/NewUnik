namespace Unik.Applicaiton.Booking.Command;

public interface IEditBookingCommand
{
    void Edit(BookingEditRequestDto dto);
}
namespace Unik.Applicaiton.Booking.Command
{
    public interface ICreateBookingCommand
    {
        void Create(BookingCreateRequestDto requestDto);
    }
}

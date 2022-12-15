namespace Unik.Applicaiton.Booking.Command
{
    public class BookingCreateRequestDto
    {
        public int Id { get; set; }
        public int OpgaveId { get; set; }
        public int MedarbejderId { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public int Varighed { get; set; }

    }
}

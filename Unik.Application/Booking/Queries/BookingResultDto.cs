using Unik.Crosscut.Dto;

namespace Unik.Applicaiton.Booking.Queries
{
    public class BookingResultDto
    {
        public int Id { get; set; }
        public int OpgaveId { get; set; }
        public int MedarbejderId { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public string MedarbejderNavn { get; set; }
    }
}

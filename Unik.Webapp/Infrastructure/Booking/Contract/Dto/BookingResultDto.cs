using System.ComponentModel.DataAnnotations;

namespace Unik.WebApp.Infrastructure.Booking.Contract.Dto
{
    public class BookingResultDto
    {
        public string MedarbejderNavn { get; set; }
        public string OpgaveType { get; set; }
        public string ProjektNavn { get; set; }
        public int OpgaveId { get; set; }
        public int MedarbejderId { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set;}
    }
}

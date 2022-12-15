using System.ComponentModel.DataAnnotations;

namespace Unik.WebApp.Infrastructure.Booking.Contract.Dto
{
    public class BookingCreateRequestDto
    {
        public int OpgaveId { get; set; }
        public int MedarbejderId { get; set; }
        public DateTime startDato { get; set; }
        public DateTime SlutDato { get; set;}
    }
}

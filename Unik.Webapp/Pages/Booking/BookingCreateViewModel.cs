using Unik.WebApp.Infrastructure.Booking.Contract.Dto;

namespace Unik.WebApp.Pages.Booking
{
    public class BookingCreateViewModel
    {
        public int OpgaveId { get; set; }
        public int MedarbejderId { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set;}
        public int Varighed { get; set; }
    }
}

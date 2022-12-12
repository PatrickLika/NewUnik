using Unik.WebApp.Infrastructure.Booking.Contract.Dto;

namespace Unik.WebApp.Pages.Booking
{
    public class BookingCreateViewModel
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public int OpgaveId { get; set; }

       // public List<EntityOpgave> opgave { get; set; }

        public int MedarbejderId { get; set; }

    }
}

using Unik.Domain.Booking.Model;
using Unik.Domain.Kompetence.Model;
using Unik.Domain.Opgave.Model;
using Unik.Domain.Projekt.Model;

namespace Unik.Applicaiton.Medarbejder.Query

{
    public class MedarbejderGetQueryDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }
        public byte[]? RowVersion { get; set; }
        public string UserId { get; set; }
        public List<BookingEntity>? BookingListe { get; set; }
    }
}

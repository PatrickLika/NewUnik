using Unik.Crosscut.Dto;
using Unik.Domain.Booking.Model;
using Unik.Domain.Opgave.Model;

namespace Unik.Applicaiton.Medarbejder.Query
{
    public class MedarbejderGetByUserIdDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }
        public byte[] RowVersion { get; set; }
        public string UserId { get; set; }
        public List<KompetenceEntityDto>? KompetenceListe { get; set; }
        public List<BookingEntityDto>? BookingListe { get; set; }

    }
}
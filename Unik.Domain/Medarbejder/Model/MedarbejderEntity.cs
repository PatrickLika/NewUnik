
using System.ComponentModel.DataAnnotations;
using Unik.Domain.Booking.Model;
using Unik.Domain.Kompetence.Model;

namespace Unik.Domain.Medarbejder.Model

{
    public class MedarbejderEntity
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string UserId { get; set; }
        public List<KompetenceEntity>? KompetenceListe { get; set; }
        public List<BookingEntity>? BookingListe { get; set; }


        public MedarbejderEntity()
        {

        }

        public MedarbejderEntity(string navn, string email, string tlf, string titel, string userId)
        {
            Navn = navn;
            Email = email;
            Tlf = tlf;
            Titel = titel;
            UserId = userId;
        }

        public void Edit(string navn, string email, string tlf, string titel, byte[] rowversion)
        {
            Navn = navn;
            Email = email;
            Tlf = tlf;
            Titel = titel;
            RowVersion = rowversion;
        }

    }
}

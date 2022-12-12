using System.ComponentModel.DataAnnotations;
using Unik.Domain.Booking.Model;
using Unik.Domain.Medarbejder.Model;
using Unik.Domain.Projekt.Model;

namespace Unik.Applicaiton.Opgave.Command
{
    public class OpgaveEditRequestDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public byte[] RowVersion { get; set; }
        public int Varighed { get; set; }
        public string Type { get; set; }
        public int ProjektId { get; set; }
        public int? MedarbejderId { get; set; }
        public int? BookingId { get; set; }
    }
}

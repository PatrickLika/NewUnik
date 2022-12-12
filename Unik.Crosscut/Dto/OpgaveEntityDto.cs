using System.ComponentModel.DataAnnotations;
using Unik.Domain.Booking.DomainServices;
using Unik.Domain.Booking.Model;
using Unik.Domain.Medarbejder.Model;
using Unik.Domain.Opgave.DomainService;
using Unik.Domain.Projekt.Model;

namespace Unik.Domain.Opgave.Model
{
    public class OpgaveEntityDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public ProjektEntityDto Projekt { get; set; }
        public int ProjektId { get; set; }
        public MedarbejderEntityDto? Medarbejder { get; set; }
        public int? MedarbejderId { get; set; }
        public BookingEntityDto? booking { get; set; }
        public int? BookingId { get; set; }
        public int Varighed { get; set; }
        public string Type { get; set; }
        
    }
}

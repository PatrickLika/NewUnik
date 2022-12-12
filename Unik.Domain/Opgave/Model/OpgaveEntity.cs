using System.ComponentModel.DataAnnotations;
using Unik.Domain.Booking.DomainServices;
using Unik.Domain.Booking.Model;
using Unik.Domain.Medarbejder.Model;
using Unik.Domain.Opgave.DomainService;
using Unik.Domain.Projekt.Model;

namespace Unik.Domain.Opgave.Model
{
    public class OpgaveEntity
    {
        private readonly IOpgaveDomainService _domainService;

        internal OpgaveEntity()
        {

        }
        public int Id { get; set; }
        public string Navn { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public ProjektEntity Projekt { get; set; }
        public int ProjektId { get; set; }
        public MedarbejderEntity? Medarbejder { get; set; }
        public int? MedarbejderId { get; set; }
        public BookingEntity? booking { get; set; }
        public int? BookingId { get; set; }
        public int Varighed { get; set; }
        public string Type { get; set; }
        
        public OpgaveEntity(IOpgaveDomainService domainService,string navn, int projektId, string type)
        {
            _domainService = domainService;
            Navn = navn;
            ProjektId = projektId;
            Type = type;
            beregnVarighed(projektId);
        }

        public void Edit(string navn, int projektId, Byte[] rowVersion, int? medarbejderId, int? bookingId, string type)
        {
            Navn = navn;
            ProjektId = projektId;
            RowVersion = rowVersion;
            MedarbejderId = medarbejderId;
            BookingId = bookingId;
            Type = type;
        }
        private void beregnVarighed(int projektId)
        {
            Varighed = _domainService.BeregnOpgaveVarighed(projektId) / 100;
        }
    }
}

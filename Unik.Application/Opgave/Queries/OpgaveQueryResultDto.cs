using Unik.Domain.Projekt.Model;

namespace Unik.Applicaiton.Opgave.Queries
{
    public class OpgaveQueryResultDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public byte[] RowVersion { get; set; }
        public int ProjektId { get; set; }
        public int? MedarbejderId { get; set;}
        public int? BookingId { get; set; }
        public int Varighed { get; set; }
        public string Type { get; set; }

    }
}

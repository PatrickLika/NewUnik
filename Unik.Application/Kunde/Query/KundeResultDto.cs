using Unik.Domain.Projekt.Model;

namespace Unik.Applicaiton.Kunde.Query
{
    public class KundeResultDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string VirksomhedNavn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }

        public string UserId { get; set; }

        public byte[] RowVersion { get; set; }

        public List<ProjektEntity> ProjektListe { get; set; }
    }
}

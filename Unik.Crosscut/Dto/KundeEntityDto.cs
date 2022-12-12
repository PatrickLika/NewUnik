using System.ComponentModel.DataAnnotations;
using Unik.Domain.Projekt.Model;

namespace Unik.Domain.Kunde.Model
{
    public class KundeEntityDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string VirksomhedNavn { get; set; }
        public string Tlf { get; set; }
        public string Email { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }
        public ProjektEntityDto Projekt { get; set; }
        public string UserId { get; set; }
    }
}

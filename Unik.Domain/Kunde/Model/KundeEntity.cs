using System.ComponentModel.DataAnnotations;
using Unik.Domain.Projekt.Model;

namespace Unik.Domain.Kunde.Model
{
    public class KundeEntity
    {
        internal KundeEntity()
        {

        }

        public int Id { get; set; }
        public string Navn { get; set; }
        public string VirksomhedNavn { get; set; }
        public string Tlf { get; set; }
        public string Email { get; set; }
        [Timestamp] public byte[] RowVersion { get; private set; }
        public ProjektEntity Projekt { get; set; }
        public string UserId { get; set; }

        public KundeEntity(string navn, string virksomhedNavn, string tlf, string email, string userId)
        {
            Navn = navn;
            VirksomhedNavn = virksomhedNavn;
            Tlf = tlf;
            Email = email;
            UserId = userId;
        }

        public void Edit(int id, string navn, string virksomhedNavn, string tlf, byte[] rowVersion)
        {
            Id = id;
            Navn = navn;
            VirksomhedNavn = virksomhedNavn;
            Tlf = tlf;
            RowVersion = rowVersion;
        }
    }
}

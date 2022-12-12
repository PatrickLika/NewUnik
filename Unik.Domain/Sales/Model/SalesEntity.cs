using System.ComponentModel.DataAnnotations;
using Unik.Domain.Kompetence.Model;
using Unik.Domain.Opgave.Model;
using Unik.Domain.Projekt.Model;

namespace Unik.Domain.Sales.Model

{
    public  class SalesEntity
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string UserId { get; set; }
        public List<ProjektEntity>? ProjektListe { get; set; }

        public SalesEntity()
        {

        }

        public SalesEntity(string navn, string email, string tlf, string titel, string userId)
        {
            Navn = navn;
            Email=email;
            Tlf=tlf;
            Titel=titel;
            UserId = userId;
        }

        public void Edit(string navn, string email, string tlf, string titel, byte[] rowversion)
        {
            Navn = navn;
            Email=email;
            Tlf=tlf;
            Titel=titel;
            RowVersion = rowversion;
        }

    }
}

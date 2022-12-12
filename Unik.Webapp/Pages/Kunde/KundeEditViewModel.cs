using Unik.WebApp.Infrastructure.Kunde.Contract.Dto;
using Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

namespace Unik.WebApp.Pages.Kunde
{
    public class KundeEditViewModel
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string VirksomhedsNavn { get; set; }
        public string Tlf { get; set; }
        public byte[] RowVersion { get; set; }
        public int? ProjektId { get; set; }

    }
}

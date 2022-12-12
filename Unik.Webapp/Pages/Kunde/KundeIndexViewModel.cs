using Unik.WebApp.Infrastructure.Kunde.Contract.Dto;
using Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

namespace Unik.WebApp.Pages.Kunde
{
    public class KundeIndexViewModel
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string VirksomhedNavn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string UserId { get; set; }
        public byte[] RowVersion { get; set; }

        public int ProjektId { get; set; }

    }
}

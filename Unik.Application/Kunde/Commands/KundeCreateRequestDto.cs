using Unik.Domain.Projekt.Model;

namespace Unik.Applicaiton.Kunde.Commands
{
    public class KundeCreateRequestDto
    {
        public string Navn { get; set; }
        public string VirksomhedsNavn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string UserId { get; set; }

    }
}

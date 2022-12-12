namespace Unik.WebApp.Infrastructure.Kunde.Contract.Dto
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

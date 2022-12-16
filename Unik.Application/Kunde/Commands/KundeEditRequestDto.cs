namespace Unik.Applicaiton.Kunde.Commands
{
    public class KundeEditRequestDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string VirksomhedNavn { get; set; }
        public string Tlf { get; set; }
        public byte[] RowVersion { get; set; }
        public int? ProjektId { get; set; }
    }
}

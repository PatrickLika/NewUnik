namespace Unik.WebApp.Infrastructure.Kunde.Contract.Dto
{
    public class KundeGetAllQueryDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string VirksomhedNavn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }

        public string UserId { get; set; }

        public byte[] RowVersion { get; set; }
    }
}

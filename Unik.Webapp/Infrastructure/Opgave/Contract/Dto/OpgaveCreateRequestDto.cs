namespace Unik.WebApp.Infrastructure.Opgave.Contract.Dto
{
    public class OpgaveCreateRequestDto
    {
        public string Navn { get; set; }
        public int ProjektId { get; set; }
        public string Type { get; set; }
    }
}

using Unik.WebApp.Infrastructure.Kompetence.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Medarbej.Contract.Dto
{
    public class MedarbejderGetQueryDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }
        public byte[]? RowVersion { get; set; }
        public string UserId { get; set; }
    }
}

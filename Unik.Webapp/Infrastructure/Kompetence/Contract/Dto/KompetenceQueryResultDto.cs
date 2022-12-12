using Unik.WebApp.Infrastructure.Medarbej.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Kompetence.Contract.Dto
{
    public class KompetenceQueryResultDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Type { get; set; }
        public byte[] RowVersion { get; set; }
        public List<MedarbejderGetAllQueryDto>? MedarbejderListe { get; set; }

    }
}

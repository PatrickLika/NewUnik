using Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Sales.Contract.Dto

{
    public class SalesGetQueryDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }
        public byte[] RowVersion { get; set; }
        public string UserId { get; set; }
        public List<ProjektQueryResultDto>? ProjektListe { get; set; }
    }
}

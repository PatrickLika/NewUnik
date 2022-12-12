using Unik.Domain.Kompetence.Model;
using Unik.Domain.Opgave.Model;
using Unik.Domain.Projekt.Model;

namespace Unik.Applicaiton.Sales.Query
{
    public class SalesGetAllQueryDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }
        public byte[] RowVersion { get; set; }
        public string UserId { get; set; }
        public List<ProjektEntity> ? ProjektListe { get; set; } 

    }
}

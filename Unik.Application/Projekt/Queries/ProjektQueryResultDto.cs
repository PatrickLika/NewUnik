using Unik.Domain.Kunde.Model;
using Unik.Domain.Medarbejder.Model;
using Unik.Domain.Opgave.Model;
using Unik.Domain.Sales.Model;

namespace Unik.Applicaiton.Projekt.Queries;

public class ProjektQueryResultDto
{
    public int Id { get; set; }
    public string Noter { get; set; }
    public byte[] RowVersion { get; set; }
    public int kundeID { get; set; }
    public int SalesId { get; set; }
    public List<OpgaveEntity>? Opgaver { get; set; }
    public int AntalBoliger { get; set; }
}
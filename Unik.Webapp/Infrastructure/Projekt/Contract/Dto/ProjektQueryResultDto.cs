using Unik.WebApp.Infrastructure.Opgave.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

public class ProjektQueryResultDto
{
    public int Id { get; set; }
    public string Noter { get; set; }
    public byte[] RowVersion { get; set; }
    public int kundeID { get; set; }
    public int SalesId { get; set; }
    public List<OpgaveQueryResultDto>? Opgaver { get; set; }
    public int AntalBoliger { get; set; }
}
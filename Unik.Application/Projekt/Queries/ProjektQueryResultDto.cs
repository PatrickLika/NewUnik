using Unik.Crosscut.Dto;

namespace Unik.Applicaiton.Projekt.Queries;

public class ProjektQueryResultDto
{
    public int Id { get; set; }
    public string Noter { get; set; }
    public byte[] RowVersion { get; set; }
    public int kundeID { get; set; }
    public int SalesId { get; set; }
    public List<OpgaveEntityDto>? Opgaver { get; set; }
    public int AntalBoliger { get; set; }
}
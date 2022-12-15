using System.ComponentModel.DataAnnotations;

namespace Unik.Crosscut.Dto;

public class ProjektEntityDto
{
    public int Id { get; set; }
    public string Noter { get; set; }
    public int AntalBoliger { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; private set; }
    public List<OpgaveEntityDto>? Opgaver { get; set; }
    public KundeEntityDto Kunde { get; set; }
    public int KundeId { get; set; }
    public SalesEntityDto Sales { get; set; }
    public int SalesId { get; set; }
}
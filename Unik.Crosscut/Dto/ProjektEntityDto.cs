using System.ComponentModel.DataAnnotations;
using Unik.Domain.Kunde.Model;
using Unik.Domain.Medarbejder.Model;
using Unik.Domain.Opgave.Model;
using Unik.Domain.Sales.Model;

namespace Unik.Domain.Projekt.Model;

public class ProjektEntityDto
{
    public string VirksomhedensNavn { get; set; }
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
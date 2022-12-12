using System.ComponentModel.DataAnnotations;
using Unik.Domain.Kunde.Model;
using Unik.Domain.Medarbejder.Model;
using Unik.Domain.Opgave.Model;
using Unik.Domain.Sales.Model;

namespace Unik.Domain.Projekt.Model;

public class ProjektEntity
{
    public ProjektEntity()
    {

    }
    public int Id { get; set; }
    public string Noter { get; set; }
    public int AntalBoliger { get; set; }
    [Timestamp] 
    public byte[] RowVersion { get; private set; }
    public List<OpgaveEntity>? Opgaver { get; set; }
    public KundeEntity Kunde { get; set; }
    public int KundeId { get; set; }
    public SalesEntity Sales { get; set; }
    public int SalesId { get; set; }

    public ProjektEntity(string noter,int kundeId, int salesId, int antalBoliger)
    {
        Noter = noter;
        KundeId = kundeId;
        SalesId = salesId;
        AntalBoliger = antalBoliger;
    }
    public void Edit(string noter, byte[] rowVersion,int kundeId, int salesId, int antalBoliger)
    {
        Noter = noter;
        RowVersion = rowVersion;
        KundeId = kundeId;
        SalesId = salesId;
        AntalBoliger = antalBoliger;
    }
}
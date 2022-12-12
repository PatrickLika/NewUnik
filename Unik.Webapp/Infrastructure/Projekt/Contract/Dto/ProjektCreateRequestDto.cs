namespace Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

public class ProjektCreateRequestDto
{
    public string Noter { get; set; }
    public int KundeId { get; set; }
    public int SalesId { get; set; }
    public int AntalBoliger { get; set; }
}
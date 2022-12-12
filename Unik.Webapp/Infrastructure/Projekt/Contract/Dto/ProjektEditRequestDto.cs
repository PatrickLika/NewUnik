namespace Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

public class ProjektEditRequestDto
{
    public int id { get; set; }
    public string Noter { get; set; }
    public byte[] RowVersion { get; set; }
    public int SælgerId { get; set; }
    public int KundeId { get; set; }
    public int AntalBoliger { get; set; }
}
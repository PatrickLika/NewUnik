using Unik.Crosscut.Dto;

namespace Unik.WebApp.Pages.MinSide;

public class IndexMedarbejderModel
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public string Email { get; set; }
    public string Tlf { get; set; }
    public string Titel { get; set; }
    public byte[] RowVersion { get; set; }
    public string UserId { get; set; }
    public List<KompetenceEntityDto>? KompetenceListe { get; set; }
    public List<OpgaveEntityDto>? OpgaverListe { get; set; }
    public List<BookingEntityDto>? BookingListe { get; set; }
}
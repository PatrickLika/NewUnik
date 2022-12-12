using System.ComponentModel.DataAnnotations;

namespace Unik.WebApp.Pages.Opgave;

public class OpgaveEditViewModel
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public byte[] RowVersion { get; set; }
    public int Varighed { get; set; }
    public string Type { get; set; }
    public int ProjektId { get; set; }
    public int? MedarbejderId { get; set;}
    public int? BookingId { get; set; }
}
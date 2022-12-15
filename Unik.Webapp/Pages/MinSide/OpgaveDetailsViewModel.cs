namespace Unik.Webapp.Pages.MinSide;

public class OpgaveDetailsViewModel
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public int Varighed { get; set; }
    public string Type { get; set; }
    public int ProjektId { get; set; }
    public int? MedarbejderId { get; set; }
    public int? BookingId { get; set; }
}
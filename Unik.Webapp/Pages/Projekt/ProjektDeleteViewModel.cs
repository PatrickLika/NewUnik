namespace Unik.WebApp.Pages.Projekt;

public class ProjektDeleteViewModel
{
    public int Id { get; set; }
    public bool? Status { get; set; }
    public DateTime? StarDato { get; set; }
    public DateTime? SlutDato { get; set; }
    public string? Noter { get; set; }
    public DateTime? TeknikerTid { get; set; }
    public DateTime? KonverterTid { get; set; }
    public DateTime? KonsulentTid { get; set; } //TODO attributter være overens med domain model
    public byte[]? RowVersion { get; set; }
}
using Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

namespace Unik.WebApp.Pages.Sales;

public class SalesIndexViewModel
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public string Email { get; set; }
    public string Tlf { get; set; }
    public string Titel { get; set; }
    public string UserId { get; set; }
    public List<ProjektQueryResultDto>? Projekter { get; set; }
}
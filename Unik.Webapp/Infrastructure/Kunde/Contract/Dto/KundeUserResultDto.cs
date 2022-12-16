using Unik.Crosscut.Dto;

namespace Unik.WebApp.Infrastructure.Kunde.Contract.Dto;

public class KundeUserResultDto
{
    public string VirksomhedNavn { get; set; }
    public ProjektEntityDto Projekt { get; set; }
    public List<OpgaveEntityDto> OpgaveListe { get; set; }
    public List<BookingEntityDto> BookingListe { get; set; }
}
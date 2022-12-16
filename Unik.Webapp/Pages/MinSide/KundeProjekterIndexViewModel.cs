using Unik.Crosscut.Dto;

namespace Unik.Webapp.Pages.Kunde;

public class KundeProjekterIndexViewModel
{
    public string VirksomhedNavn { get; set; }
    public ProjektEntityDto Projekt { get; set; }
    public List<OpgaveEntityDto> OpgaveListe { get; set; }
    public List<BookingEntityDto> BookingListe { get; set; }
}
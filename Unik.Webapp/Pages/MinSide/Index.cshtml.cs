using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kunde.Contract;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Opgave.Contract;
using Unik.WebApp.Infrastructure.Projekt.Contract;
using Unik.WebApp.Pages.Opgave;
using Unik.WebApp.Pages.Projekt;

namespace Unik.WebApp.Pages.MinSide
{
    public class IndexModel : PageModel
    {
        private readonly IOpgaveService _opgaveService;
        private readonly IMedarbejderService _medarbejderService;
        private readonly IKundeService _kundeService;
        private readonly IProjektService _projektService;

        public IndexModel(IOpgaveService opgaveService, IMedarbejderService medarbejderService, IKundeService kundeService, IProjektService projektService)
        {
            _opgaveService = opgaveService;
            _medarbejderService = medarbejderService;
            _kundeService = kundeService;
            _projektService = projektService;
        }

        [BindProperty] public List<OpgaveIndexViewModel> OpgaveIndexViewModels { get; set; } = new();
        [BindProperty] public List<ProjektIndexViewModel> ProjektIndexViewModels { get; set; } = new();


        public async Task<IActionResult> OnGet()
        {
            if (User.HasClaim(a => a.Type == "Tekniker"))
            {
                var opgaveListe = await _opgaveService.getAll();

                var medarbejderliste = await _medarbejderService.GetAll();
                var specifikmedarbejder = medarbejderliste.Where(a => a.UserId == User.Identity.Name).SingleOrDefault();


                var specifikTeknikerOpgaveListe = opgaveListe.Where(a => a.MedarbejderId == specifikmedarbejder.Id);


                specifikTeknikerOpgaveListe.ToList().ForEach(dto => OpgaveIndexViewModels.Add(new OpgaveIndexViewModel()
                {
                    Id = dto.Id,
                    ProjektId = dto.ProjektId,
                    Navn = dto.Navn
                }));
                return Page();
            }

            if (User.HasClaim(a => a.Type == "Kunde"))
            {
                var kundeListe = await _kundeService.GetAll();
                var specifikKunde = kundeListe.ToList().Where(a => a.UserId == User.Identity.Name).ToList().SingleOrDefault();
                if (specifikKunde == null) throw new Exception("Kunden findes ikke");
                var projektListe = await _projektService.ProjektGetAll();

                var kundeProjektListe = projektListe.ToList().Where(a => a.kundeID == specifikKunde.Id);
                if (kundeProjektListe == null) throw new Exception("Kunde er ikke tilknyttet nogle projekter");
                kundeProjektListe.ToList().ForEach(dto => ProjektIndexViewModels.Add(new ProjektIndexViewModel
                {
                    Id = dto.Id,
                    kundeID = dto.kundeID,
                    SalesId = dto.SalesId,
                    Noter = dto.Noter
                }));

                return Page();
            }


            return Page();
        }
    }
}

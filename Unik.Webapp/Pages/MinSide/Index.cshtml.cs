using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kompetence.Contract;
using Unik.WebApp.Infrastructure.Kunde.Contract;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Opgave.Contract;
using Unik.WebApp.Infrastructure.Projekt.Contract;
using Unik.WebApp.Pages.Projekt;

namespace Unik.WebApp.Pages.MinSide
{
    public class IndexModel : PageModel
    {
        private readonly IOpgaveService _opgaveService;
        private readonly IMedarbejderService _medarbejderService;
        private readonly IKundeService _kundeService;
        private readonly IProjektService _projektService;
        private readonly IkompetenceService _kompetenceService;

        public IndexModel(IOpgaveService opgaveService, IMedarbejderService medarbejderService, IKundeService kundeService, IProjektService projektService, IkompetenceService kompetenceService)
        {
            _opgaveService = opgaveService;
            _medarbejderService = medarbejderService;
            _kundeService = kundeService;
            _projektService = projektService;
            _kompetenceService = kompetenceService;
        }

        [BindProperty] public IndexMedarbejderModel MedarbejderModel { get; set; } = new();
        [BindProperty] public List<ProjektIndexViewModel> ProjektIndexViewModels { get; set; } = new();


        public async Task<IActionResult> OnGet()
        {
            if (User.HasClaim(a => a.Type == "Tekniker") || User.HasClaim(a => a.Type == "Konsulent") || User.HasClaim(a => a.Type == "Konverter"))
            {
                var user = await _medarbejderService.GetByUserId(User.Identity.Name);


                MedarbejderModel.BookingListe = user.BookingListe;
                MedarbejderModel.Email = user.Email;
                MedarbejderModel.Id = user.Id;
                MedarbejderModel.KompetenceListe = user.KompetenceListe;
                MedarbejderModel.Navn = user.Navn;
                MedarbejderModel.Titel = user.Titel;
                MedarbejderModel.OpgaverListe = user.OpgaverListe;
                return Page();
            }

            return Page();
        }
    }
}

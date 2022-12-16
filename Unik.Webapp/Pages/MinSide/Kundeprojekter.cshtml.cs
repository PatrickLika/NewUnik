using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kunde.Contract;

namespace Unik.Webapp.Pages.Kunde
{
    public class KundeprojekterModel : PageModel
    {
        private readonly IKundeService _kundeService;
        public KundeProjekterIndexViewModel KundeIndexViewModel { get; set; }
        public KundeprojekterModel(IKundeService kundeService)
        {
            _kundeService = kundeService;
        }
        public async Task<IActionResult> OnGet()
        {
            if (User.HasClaim(a => a.Value == "Kunde"))
            {
                var kunde = await _kundeService.GetByUserId(User.Identity.Name);

                KundeIndexViewModel = new KundeProjekterIndexViewModel()
                {
                    BookingListe = kunde.BookingListe,
                    OpgaveListe = kunde.OpgaveListe,
                    Projekt = kunde.Projekt,
                    VirksomhedNavn = kunde.VirksomhedNavn
                };

            }


            return Page();
        }
    }
}

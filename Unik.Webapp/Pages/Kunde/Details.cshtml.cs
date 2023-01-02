using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kunde.Contract;
using Unik.WebApp.Infrastructure.Projekt.Contract;

namespace Unik.WebApp.Pages.Kunde
{
    public class DetailsModel : PageModel
    {
        private readonly IKundeService _kundeService;
        private readonly IProjektService _projektService;

        public DetailsModel(IKundeService kundeService, IProjektService projektService)
        {
            _kundeService = kundeService;
            _projektService = projektService;
        }

        [BindProperty] public KundeDetailsViewModel DetailsViewModel { get; set; } = new();
        public async Task<IActionResult> OnGet(int id)
        {
            //if (TryValidateModel(string.IsNullOrWhiteSpace(userId))) return NotFound();

            var model = await _kundeService.Get(id);

            if (model == null) throw new Exception("der var ikke nogen kunde med det Id");

            var projekt = await _projektService.ProjektGetAll();

            var kundeProjekt = projekt.Where(a => a.kundeID == id).First();

            if (kundeProjekt == null) throw new Exception("kunden har ingen projekter");



            DetailsViewModel.Id = model.Id;
            DetailsViewModel.Navn = model.Navn;
            DetailsViewModel.VirksomhedsNavn = model.VirksomhedNavn;
            DetailsViewModel.Email = model.Email;
            DetailsViewModel.Tlf = model.Tlf;
            DetailsViewModel.UserId = model.UserId;
            DetailsViewModel.ProjektId = kundeProjekt.Id;


            return Page();
        }
    }
}

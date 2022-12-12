using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kunde.Contract;
using Unik.WebApp.Infrastructure.Kunde.Contract.Dto;

namespace Unik.WebApp.Pages.Kunde
{
    public class CreateModel : PageModel
    {
        private readonly IKundeService _kundeService;

        public CreateModel(IKundeService kundeService)
        {
            _kundeService = kundeService;
        }
        [BindProperty] public KundeCreateViewModel KundeCreateViewModel { get; set; } = new();

        public ActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(string message)
        {
            if (!ModelState.IsValid) return Page();

            var KundeDto = new KundeCreateRequestDto()
            {
                Navn = KundeCreateViewModel.Navn,
                VirksomhedsNavn = KundeCreateViewModel.VirksomhedsNavn,
                Email = message,
                Tlf = KundeCreateViewModel.Tlf,
                UserId = message
            };

            try
            {
                await _kundeService.Create(KundeDto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }

            return new RedirectToPageResult("./index");

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
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
            try
            {
                if (!ModelState.IsValid || KundeCreateViewModel.Navn.IsNullOrEmpty() ||
                    KundeCreateViewModel.Tlf.IsNullOrEmpty() ||
                    KundeCreateViewModel.VirksomhedsNavn.IsNullOrEmpty()) new Exception();

                var KundeDto = new KundeCreateRequestDto()
                {
                    Navn = KundeCreateViewModel.Navn,
                    VirksomhedsNavn = KundeCreateViewModel.VirksomhedsNavn,
                    Email = message,
                    Tlf = KundeCreateViewModel.Tlf,
                    UserId = message
                };


                await _kundeService.Create(KundeDto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }

            return new RedirectToPageResult("./index");

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Projekt.Contract;
using Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

namespace Unik.WebApp.Pages.Projekt
{
    public class CreateModel : PageModel
    {
        private readonly IProjektService _projektService;

        public CreateModel(IProjektService projektService)
        {
            _projektService = projektService;
        }
        [BindProperty] public ProjektCreateViewModel ProjektViewModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            var dto = new ProjektCreateRequestDto()
            {
                SalesId = ProjektViewModel.SalesId,
                KundeId = ProjektViewModel.KundeId,
                Noter = ProjektViewModel.Noter,
                AntalBoliger = ProjektViewModel.AntalBoliger
            };
            await _projektService.ProjektCreate(dto);

            return new RedirectToPageResult("./index");

        }
    }
}

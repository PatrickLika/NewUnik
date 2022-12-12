using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Sales.Contract;
using Unik.WebApp.Infrastructure.Sales.Contract.Dto;

namespace Unik.WebApp.Pages.Sales
{
    public class CreateModel : PageModel
    {
        private readonly ISalesService _salesService;
        [BindProperty] public SalesCreateViewModel CreateViewModel { get; set; } = new();
        public CreateModel(ISalesService salesService)
        {
            _salesService = salesService;
        }
        public ActionResult OnGet(string message)
        {

            CreateViewModel.UserId = message;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var dto = new SalesCreateRequestDto()
            {
                Email = CreateViewModel.Email,
                Navn = CreateViewModel.Navn,
                Titel = CreateViewModel.Titel,
                Tlf = CreateViewModel.Tlf,
                UserId = CreateViewModel.UserId
            };

            await _salesService.SalesCreate(dto);

            return RedirectToPage("./index");
        }

    }
}

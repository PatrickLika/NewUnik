using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Sales.Contract;
using Unik.WebApp.Pages.Projekt;

namespace Unik.WebApp.Pages.Sales
{
    public class DetailsModel : PageModel
    {
        private readonly ISalesService _salesService;

        public DetailsModel(ISalesService salesService)
        {
            _salesService = salesService;
        }
        [BindProperty] public List<SalesIndexViewModel> DetailsViewModel { get; set; } = new();

        public async Task OnGet(int? Id)
        {
            var salger = await _salesService.SalesGet(Id.Value);

            var dto = new SalesIndexViewModel()
            {
                Id = salger.Id,
                Email = salger.Email,
                Navn = salger.Navn,
                UserId = salger.UserId,
                Projekter = salger.ProjektListe,
                Titel = salger.Titel,
                Tlf = salger.Tlf
            };

            DetailsViewModel.Add(dto);
        }
    }
}

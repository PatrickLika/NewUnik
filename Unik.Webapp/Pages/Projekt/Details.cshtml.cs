using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Projekt.Contract;

namespace Unik.WebApp.Pages.Projekt
{
    public class DetailsModel : PageModel
    {
        private readonly IProjektService _projektService;

        public DetailsModel(IProjektService projektService)
        {
            _projektService = projektService;
        }
        [BindProperty] public List<ProjektIndexViewModel> DetailsViewModel { get; set; } = new();
        public async Task OnGet(int? id)
        {
            var projekter = await _projektService.ProjektGet(id.Value);

            var dto = new ProjektIndexViewModel()
            {
                RowVersion = projekter.RowVersion,
                Id = projekter.Id,
                Noter = projekter.Noter,
                SalesId = projekter.SalesId,
                Opgaver = projekter.Opgaver,
                AntalBoliger = projekter.AntalBoliger,
                kundeID = projekter.kundeID
            };
            DetailsViewModel.Add(dto);

        }
    }
}

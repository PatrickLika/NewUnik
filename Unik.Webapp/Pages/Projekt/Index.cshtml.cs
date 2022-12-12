using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Projekt.Contract;

namespace Unik.WebApp.Pages.Projekt
{
    public class IndexModel : PageModel
    {
        private readonly IProjektService _projektService;

        [BindProperty] public List<ProjektIndexViewModel> IndexViewModel { get; set; } = new();
        public IndexModel(IProjektService projektService)
        {
            _projektService = projektService;
        }
        public async Task OnGet()
        {
            var projekter = await _projektService.ProjektGetAll();

            projekter.ToList().ForEach(dto => IndexViewModel.Add(new ProjektIndexViewModel
            {
                RowVersion = dto.RowVersion,
                Id = dto.Id,
                SalesId = dto.SalesId,
                Noter = dto.Noter,
                Opgaver = dto.Opgaver,
                kundeID = dto.kundeID,
                AntalBoliger = dto.AntalBoliger
            }));


        }
    }
}

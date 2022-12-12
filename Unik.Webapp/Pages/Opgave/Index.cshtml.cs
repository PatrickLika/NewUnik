using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Opgave.Contract;

namespace Unik.WebApp.Pages.Opgave
{
    public class IndexModel : PageModel
    {
        private readonly IOpgaveService _opgaveService;

        public IndexModel(IOpgaveService opgaveService)
        {
            _opgaveService = opgaveService;
        }
        [BindProperty] public List<OpgaveIndexViewModel> OpgaveIndexViewModel { get; set; } = new();
        public async Task OnGet()
        {
            var businessModel = await _opgaveService.getAll();

            businessModel.ToList().ForEach(dto => OpgaveIndexViewModel.Add(new OpgaveIndexViewModel()
            {
                Id = dto.Id,
                Navn = dto.Navn,
                RowVersion = dto.RowVersion,
                ProjektId = dto.ProjektId,
                BookingId = dto.BookingId,
                MedarbejderId = dto.MedarbejderId,
                Type = dto.Type,
                Varighed = dto.Varighed
            }));
        }

        public async Task OnPost()
        {

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Opgave.Contract;

namespace Unik.Webapp.Pages.MinSide
{
    public class OpgaveDetailsModel : PageModel
    {
        private readonly IOpgaveService _opgaveService;

        public OpgaveDetailsViewModel OpgaveDetailsViewModel { get; set; } = new();
        public OpgaveDetailsModel(IOpgaveService opgaveService)
        {
            _opgaveService = opgaveService;
        }
        public async Task<IActionResult> OnGet(int id)
        {

            var result = await _opgaveService.Get(id);



            OpgaveDetailsViewModel = new OpgaveDetailsViewModel()
            {
                BookingId = result.BookingId,
                Id = result.Id,
                MedarbejderId = result.MedarbejderId,
                Navn = result.Navn,
                Type = result.Type,
                ProjektId = result.ProjektId,
                Varighed = result.Varighed
            };

            return Page();
        }
    }
}

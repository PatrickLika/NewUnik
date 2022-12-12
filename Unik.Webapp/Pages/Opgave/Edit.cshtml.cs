using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Opgave.Contract;
using Unik.WebApp.Infrastructure.Opgave.Contract.Dto;

namespace Unik.WebApp.Pages.Opgave
{
    public class EditModel : PageModel
    {
        private readonly IOpgaveService _opgaveService;


        [BindProperty] public OpgaveEditViewModel OpgaveEditViewModel { get; set; }
        public EditModel(IOpgaveService opgaveService)
        {
            _opgaveService = opgaveService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            var dto = await _opgaveService.Get(id.Value);

            OpgaveEditViewModel = new OpgaveEditViewModel()
            {
                Id = dto.Id,
                Navn = dto.Navn,
                RowVersion = dto.RowVersion,
                Varighed = dto.Varighed,
                Type = dto.Type,
                ProjektId = dto.ProjektId,
                MedarbejderId = dto.MedarbejderId,
                BookingId = dto.BookingId
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await _opgaveService.Edit(new OpgaveEditRequestDto
                {
                    Id = OpgaveEditViewModel.Id,
                    Navn = OpgaveEditViewModel.Navn,
                    RowVersion = OpgaveEditViewModel.RowVersion,
                    Varighed = OpgaveEditViewModel.Varighed,
                    Type = OpgaveEditViewModel.Type,
                    ProjektId = OpgaveEditViewModel.ProjektId,
                    MedarbejderId = OpgaveEditViewModel.MedarbejderId,
                    BookingId = OpgaveEditViewModel.BookingId
                });
            }

            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }
            return RedirectToPage("./Index");
        }

    }
}

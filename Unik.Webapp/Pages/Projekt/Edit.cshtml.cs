using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Projekt.Contract;
using Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

namespace Unik.WebApp.Pages.Projekt
{
    public class EditModel : PageModel
    {
        private readonly IProjektService _projektService;

        public EditModel(IProjektService projektService)
        {
            _projektService = projektService;
        }
        [BindProperty] public ProjektEditViewModel ViewModel { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            var dto = await _projektService.ProjektGet(id.Value);

            ViewModel = new ProjektEditViewModel
            {
                RowVersion = dto.RowVersion,
                KundeId = dto.kundeID,
                Noter = dto.Noter,
                SælgerId = dto.SalesId,
                Id = dto.Id,
                AntalBoliger = dto.AntalBoliger,
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _projektService.ProjektEdit(new ProjektEditRequestDto
            {
                RowVersion = ViewModel.RowVersion,
                Noter = ViewModel.Noter,
                KundeId = ViewModel.KundeId,
                SælgerId = ViewModel.SælgerId,
                id = ViewModel.Id,
                AntalBoliger = ViewModel.AntalBoliger,
            });

            return RedirectToPage("./Index");
        }
    }
}

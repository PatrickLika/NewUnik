using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kunde.Contract;
using Unik.WebApp.Infrastructure.Kunde.Contract.Dto;

namespace Unik.WebApp.Pages.Kunde
{
    public class EditModel : PageModel
    {
        private readonly IKundeService _kundeService;
        public EditModel(IKundeService kundeSerivce)
        {
            _kundeService = kundeSerivce;
        }
        [BindProperty] public KundeEditViewModel EditViewModel { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();
            var dto = await _kundeService.Get(id.Value);
            if (dto == null) return NotFound();

            EditViewModel = new KundeEditViewModel
            {
                Id = id.Value,
                Navn = dto.Navn,
                VirksomhedsNavn = dto.VirskomhedsNavn,
                Tlf = dto.Tlf,
                RowVersion = dto.Rowversion,
                ProjektId = dto.ProjektId
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _kundeService.Edit(new KundeEditRequestDto
            {
                Id = EditViewModel.Id,
                Navn = EditViewModel.Navn,
                VirksomhedsNavn = EditViewModel.VirksomhedsNavn,
                Tlf = EditViewModel.Tlf,
                RowVersion = EditViewModel.RowVersion,
                ProjektId = EditViewModel.ProjektId

            });
            return RedirectToPage("./Index");
        }
    }
    //TODO lave ui på EDIT
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kompetence.Contract;
using Unik.WebApp.Infrastructure.Kompetence.Contract.Dto;

namespace Unik.WebApp.Pages.Kompetence
{
    public class EditModel : PageModel
    {
        private readonly IkompetenceService _ikompetenceService;

        public EditModel(IkompetenceService ikompetenceService)
        {
            _ikompetenceService = ikompetenceService;
        }

        [BindProperty] public KompetenceIndexViewModel EditViewModel { get; set; } = new();

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            var dto = await _ikompetenceService.Get(id.Value);

            if (dto == null) return NotFound();

            EditViewModel = new KompetenceIndexViewModel
            {
                Id = dto.Id,
                Navn = dto.Navn,
                Type = dto.Type,
                RowVersion = dto.RowVersion, 
                MedarbejderListe = dto.MedarbejderListe
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await _ikompetenceService.Edit(new KompetenceEditRequestDto
                {
                    Id = EditViewModel.Id, 
                    Navn = EditViewModel.Navn, 
                    Type = EditViewModel.Type,
                    RowVersion = EditViewModel.RowVersion
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

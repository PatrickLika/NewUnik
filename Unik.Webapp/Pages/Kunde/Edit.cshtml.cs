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
                VirksomhedNavn = dto.VirksomhedNavn,
                Tlf = dto.Tlf,
                RowVersion = dto.Rowversion,
                ProjektId = dto.ProjektId
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();


            try
            {
                await _kundeService.Edit(new KundeEditRequestDto
                {
                    Id = EditViewModel.Id.Value,
                    Navn = EditViewModel.Navn,
                    VirksomhedNavn = EditViewModel.VirksomhedNavn,
                    Tlf = EditViewModel.Tlf,
                    RowVersion = EditViewModel.RowVersion,
                    ProjektId = EditViewModel.ProjektId
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

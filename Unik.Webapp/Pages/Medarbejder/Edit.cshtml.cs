using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Medarbej.Contract.Dto;

namespace Unik.WebApp.Pages.Medarbejder
{
    public class EditModel : PageModel
    {
        private readonly IMedarbejderService _medarbejderService;

        public EditModel(IMedarbejderService medarbejderService)
        {
            _medarbejderService = medarbejderService;
        }

        [BindProperty]
        public MedarbejderEditViewModel MedarbejderModel { get; set; }


        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            var dto = await _medarbejderService.Get(id.Value);

            if (dto == null) return NotFound();

            MedarbejderModel = new MedarbejderEditViewModel
            {
                Id = dto.Id,
                Navn = dto.Navn,
                Email = dto.Email,
                Tlf = dto.Tlf,
                Titel = dto.Titel,
                RowVersion = dto.RowVersion,
                UserId = dto.UserId
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await _medarbejderService.Edit(new MedarbejderEditRequestDto
                {
                    Id = MedarbejderModel.Id,
                    Navn = MedarbejderModel.Navn,
                    Email = MedarbejderModel.Email,
                    Tlf = MedarbejderModel.Tlf,
                    Titel = MedarbejderModel.Titel,
                    RowVersion = MedarbejderModel.RowVersion,
                    UserId = MedarbejderModel.UserId,
                    KompetenceListe = MedarbejderModel.KompetenceListe
                });
            }

            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }

            return RedirectToPage("./index");

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Medarbej.Contract.Dto;

namespace Unik.WebApp.Pages.Medarbejder
{
    public class CreateModel : PageModel
    {
        private readonly IMedarbejderService _stamdataMedarbejderService;

        public CreateModel(IMedarbejderService stamdataMedarbejderService)
        {
            _stamdataMedarbejderService = stamdataMedarbejderService;
        }

        [BindProperty]
        public MedarbejderCreateViewModel MedarbejderModel { get; set; } = new();


        public ActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(string message)
        {
            if (!ModelState.IsValid) return Page();
            var dto = new MedarbejderCreateRequestDto
            {
                Navn = MedarbejderModel.Navn,
                Tlf = MedarbejderModel.Tlf,
                Titel = MedarbejderModel.Titel,
                Email = message,
                UserId = message,
            };

            await _stamdataMedarbejderService.Create(dto);

            return new RedirectToPageResult("/Medarbejder/Index");



        }

    }
}

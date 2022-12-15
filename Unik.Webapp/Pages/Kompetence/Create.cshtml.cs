using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Unik.WebApp.Infrastructure.Kompetence.Contract;
using Unik.WebApp.Infrastructure.Kompetence.Contract.Dto;

namespace Unik.WebApp.Pages.Kompetence
{
    public class CreateModel : PageModel
    {
        private readonly IkompetenceService _kompetenceService;

        public CreateModel(IkompetenceService kompetenceService)
        {
            _kompetenceService = kompetenceService;
        }
        [BindProperty] public KompetenceCreateViewModel CreateViewModel { get; set; } = new();


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();


            var dto = new KompetenceCreateRequestDto
            {
                Navn = CreateViewModel.Navn,
                Type = CreateViewModel.Type
            };

            try
            {
                await _kompetenceService.Create(dto);
            }

            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }

            return new RedirectToPageResult("./Index");
        }
    }
}

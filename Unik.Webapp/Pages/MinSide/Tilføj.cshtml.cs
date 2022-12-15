using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Medarbejder.Contract.Dto;

namespace Unik.Webapp.Pages.MinSide
{
    public class TilføjModel : PageModel
    {
        private readonly IMedarbejderService _medarbejderService;

        public TilføjModel(IMedarbejderService medarbejderService)
        {
            _medarbejderService = medarbejderService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) throw new Exception();

            var dto = new MedarbejderKompetenceCreateDto()
            {
                KompetenceId = id.Value,
                UserId = User.Identity.Name
            };
            await _medarbejderService.CreateMedarbejderKompetence(dto);

            return new RedirectToPageResult("./Index");

        }
    }
}

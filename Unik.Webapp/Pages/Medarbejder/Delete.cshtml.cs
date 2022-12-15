using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Medarbej.Contract;

namespace Unik.WebApp.Pages.Medarbejder
{
    public class DeleteModel : PageModel
    {
        private readonly IMedarbejderService _medarbejderService;

        public DeleteModel(IMedarbejderService medarbejderService)
        {
            _medarbejderService = medarbejderService;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            await _medarbejderService.Delete(id.Value);

            return RedirectToPage("./Index");
        }

    }
}

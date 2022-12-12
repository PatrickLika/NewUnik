using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Projekt.Contract;

namespace Unik.WebApp.Pages.Projekt
{
    public class DeleteModel : PageModel
    {
        private readonly IProjektService _projektService;
        public DeleteModel(IProjektService projektService)
        {
            _projektService = projektService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            await _projektService.ProjektDelete(id.Value);

            return RedirectToPage("./Index");
        }

        //TODO lave ui på delete -Patrick Metode & Details skal laves 
    }
}

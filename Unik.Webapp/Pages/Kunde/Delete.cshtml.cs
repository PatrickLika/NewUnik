using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kunde.Contract;

namespace Unik.WebApp.Pages.Kunde
{
    public class DeleteModel : PageModel
    {
        private readonly IKundeService _kundeService;
        public DeleteModel(IKundeService kundeService)
        {
            _kundeService = kundeService;
        }
        [BindProperty] public KundeDeleteViewModel DeleteViewModel { get; set; } 
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();
            await _kundeService.Delete(id.Value);
            return RedirectToPage("./Index");
        }
    }
}

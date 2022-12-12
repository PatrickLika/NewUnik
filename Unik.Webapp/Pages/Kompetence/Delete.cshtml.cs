using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kompetence.Contract;

namespace Unik.WebApp.Pages.Kompetence
{
    public class DeleteModel : PageModel
    {
        private readonly IkompetenceService _IkompetenceService;

        public DeleteModel(IkompetenceService IkompetenceService)
        {
            _IkompetenceService = IkompetenceService;
        }
        [BindProperty] public KompetenceDeleteViewModel DeleteViewModel { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

           await _IkompetenceService.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}

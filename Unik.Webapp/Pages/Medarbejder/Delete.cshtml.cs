using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Medarbej.Contract.Dto;
using Unik.WebApp.Infrastructure.Medarbej.Implementation;

namespace Unik.WebApp.Pages.Medarbejder
{
    public class DeleteModel : PageModel
    {
        private readonly IMedarbejderService _medarbejderService;

        public DeleteModel(IMedarbejderService medarbejderService)
        {
            _medarbejderService = medarbejderService;
        }

        [BindProperty]
        public MedarbejderDeleteViewModel MedarbejderDeleteModel { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            await _medarbejderService.Delete(id.Value);

            return RedirectToPage("./Index");
        }
       
    }
}

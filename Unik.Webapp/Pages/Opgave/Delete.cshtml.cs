using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Opgave.Contract;

namespace Unik.WebApp.Pages.Opgave
{
    public class DeleteModel : PageModel
    {
        private readonly IOpgaveService _opgaveServicevice;


        public DeleteModel(IOpgaveService opgaveServicevice)
        {
            _opgaveServicevice = opgaveServicevice;
        }


        [BindProperty] public OpgaveDeleteViewModel DeleteViewModel { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            await _opgaveServicevice.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }

}

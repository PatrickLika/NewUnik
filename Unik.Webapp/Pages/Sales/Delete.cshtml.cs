using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Sales.Contract;

namespace Unik.WebApp.Pages.Sales
{
    public class DeleteModel : PageModel
    {
        private readonly ISalesService _salesService;

        public DeleteModel(ISalesService salesService)
        {
            _salesService = salesService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            await _salesService.SalesDelete(id);

            return RedirectToPage("./Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kunde.Contract;

namespace Unik.Webapp.Pages.Kunde
{
    public class KundeprojekterModel : PageModel
    {
        private readonly IKundeService _kundeService;

        public KundeprojekterModel(IKundeService kundeService)
        {
            _kundeService = kundeService;
        }
        public async Task<IActionResult> OnGet()
        {





            return Page();
        }
    }
}

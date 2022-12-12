using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Sales.Contract;
using Unik.WebApp.Infrastructure.Sales.Contract.Dto;

namespace Unik.WebApp.Pages.Sales
{
    public class EditModel : PageModel
    {
        private readonly ISalesService _salesService;
        [BindProperty] public SalesEditViewModel EditViewModel { get; set; }
        public EditModel(ISalesService salesService)
        {
            _salesService = salesService;
        }
        public async Task OnGet(int id)
        {
            var getRequest = await _salesService.SalesGet(id);

            EditViewModel = new SalesEditViewModel()
            {
                Email = getRequest.Email,
                Id = getRequest.Id,
                RowVersion = getRequest.RowVersion,
                Navn = getRequest.Navn,
                Titel = getRequest.Titel,
                Tlf = getRequest.Tlf,
                UserId = getRequest.UserId
            };

        }

        public async Task<IActionResult> OnPost()
        {

            var dto = new SalesEditRequestDto()
            {
                Tlf = EditViewModel.Tlf,
                Email = EditViewModel.Email,
                Id = EditViewModel.Id,
                RowVersion = EditViewModel.RowVersion,
                Navn = EditViewModel.Navn,
                UserId = EditViewModel.UserId,
                Titel = EditViewModel.Titel
            };

            await _salesService.SalesEdit(dto);

           return RedirectToPage("./index");
        }
    }
}

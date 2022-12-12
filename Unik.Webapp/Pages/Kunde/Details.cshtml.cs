using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kunde.Contract;

namespace Unik.WebApp.Pages.Kunde
{
    public class DetailsModel : PageModel
    {
        private readonly IKundeService _kundeService;
        public DetailsModel(IKundeService kundeService)
        {
            _kundeService = kundeService;
        }

        [BindProperty] public List<KundeDetailsViewModel> DetailsViewModel { get; set; } = new();
        public async Task<IActionResult> OnGet(string? userId)
        {
            if (TryValidateModel(string.IsNullOrWhiteSpace(userId))) return NotFound();

            var model = await _kundeService.GetAll();

            model?.OrderBy(a => a.Id)
                .ToList()
                .ForEach(dto => DetailsViewModel.Add(new KundeDetailsViewModel
                {
                    Id = dto.Id,
                    Navn = dto.Navn,
                    VirksomhedsNavn = dto.VirksomhedNavn,
                    Email = dto.Email,
                    Tlf = dto.Tlf,
                    UserId = dto.UserId
                }));

            return Page();
        }
    }
}

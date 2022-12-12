using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kompetence.Contract;

namespace Unik.WebApp.Pages.Kompetence
{
    public class DetailsModel : PageModel
    {
        private readonly IkompetenceService _kompetenceService;
        public DetailsModel(IkompetenceService kompetenceService)
        {
            _kompetenceService = kompetenceService;
        }

        [BindProperty] public List<KompetenceDetailsViewModel> DetailsViewModel { get; set; } = new();
        public async Task<IActionResult> OnGet(string? userId)
        {
            if (TryValidateModel(string.IsNullOrWhiteSpace(userId))) return NotFound();

            var model = await _kompetenceService.getAll();

            model?.OrderBy(a => a.Id)
                .ToList()
                .ForEach(dto => DetailsViewModel.Add(new KompetenceDetailsViewModel
                {
                    Navn = dto.Navn,
                    Id = dto.Id,
                    Type = dto.Type,
                    RowVersion = dto.RowVersion
                }));

            return Page();
        }
    }
}

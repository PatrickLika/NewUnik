using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kompetence.Contract;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Medarbejder.Contract.Dto;

namespace Unik.Webapp.Pages.MinSide
{
    public class TilføjKompetenceModel : PageModel
    {
        private readonly IkompetenceService _kompetenceService;
        private readonly IMedarbejderService _medarbejderService;

        [BindProperty] public List<KompetenceViewModel> KompetenceViewIndexModel { get; set; } = new();

        [BindProperty] public TilføjKompetenceTilMedarbejderViewModel TilføjKompetenceTilMdedarbejderModel { get; set; } = new();

        public TilføjKompetenceModel(IkompetenceService kompetenceService, IMedarbejderService medarbejderService)
        {
            _kompetenceService = kompetenceService;
            _medarbejderService = medarbejderService;
        }
        public async Task<IActionResult> OnGet()
        {
            var kompetenceListe = await _kompetenceService.getAll();
            if (kompetenceListe == null) return NotFound("Der var ingen kompetencer på listen");

            kompetenceListe.ToList().ForEach(dto => KompetenceViewIndexModel.Add(new KompetenceViewModel
            {
                Type = dto.Type,
                Id = dto.Id,
                Navn = dto.Navn
            }));

            TilføjKompetenceTilMdedarbejderModel.UserId = User.Identity.Name;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var dto = new MedarbejderKompetenceCreateDto()
            {
                KompetenceId = TilføjKompetenceTilMdedarbejderModel.KompetenceId,
                UserId = User.Identity.Name
            };

            await _medarbejderService.CreateMedarbejderKompetence(dto);

            return new RedirectToPageResult("./Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kompetence.Contract;
using Unik.WebApp.Infrastructure.Opgave.Contract;
using Unik.WebApp.Infrastructure.Opgave.Contract.Dto;
using Unik.WebApp.Infrastructure.Projekt.Contract;
using Unik.WebApp.Pages.Kompetence;

namespace Unik.WebApp.Pages.Opgave
{
    public class CreateModel : PageModel
    {
        private readonly IOpgaveService _service;
        private readonly IkompetenceService _kompetenceService;
        private readonly IProjektService _projektService;
        [BindProperty] public OpgaveCreateViewModel Opgaveviewmodel { get; set; }
        [BindProperty] public List<KompetenceIndexViewModel> KompetenceListe { get; set; }

        public CreateModel(IOpgaveService service, IkompetenceService kompetenceService, IProjektService projektService)
        {
            _service = service;
            _kompetenceService = kompetenceService;
            _projektService = projektService;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();


            Opgaveviewmodel = new OpgaveCreateViewModel()
            {
                ProjektId = id.Value,
            };
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var dto = new OpgaveCreateRequestDto
            {
                ProjektId = Opgaveviewmodel.ProjektId,
                Navn = Opgaveviewmodel.Navn,
                Type = Opgaveviewmodel.Type
            };

            await _service.Create(dto);

            return RedirectToPage("/Opgave/Index");
        }
    }
}

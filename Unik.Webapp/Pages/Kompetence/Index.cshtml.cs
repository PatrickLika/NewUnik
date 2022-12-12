using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kompetence.Contract;

namespace Unik.WebApp.Pages.Kompetence
{
    public class IndexModel : PageModel
    {
        private readonly IkompetenceService _ikompetenceService;

        public IndexModel(IkompetenceService ikompetenceService)
        {
            _ikompetenceService = ikompetenceService;
        }

        [BindProperty] public List<KompetenceIndexViewModel> IndexViewModel { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGet(string SearchString)
        {

            var businessModel = await _ikompetenceService.getAll();

            if (SearchString != null)
            {
                businessModel = businessModel.Where(s => s.Navn.Contains(SearchString));
            }

            
            businessModel?.ToList().ForEach(dto => IndexViewModel.Add(new KompetenceIndexViewModel
            {
                Id = dto.Id,
                Navn = dto.Navn,
                Type = dto.Type
            }));

        }

        public async Task OnPost(string SearchString)
        {
            var businessModel = await _ikompetenceService.getAll();

            if (SearchString != null)
            {
                businessModel = businessModel.Where(s => s.Navn.Contains(SearchString));
            }

            
            businessModel?.ToList().ForEach(dto => IndexViewModel.Add(new KompetenceIndexViewModel
            {
                Id = dto.Id,
                Navn = dto.Navn,
                Type = dto.Type
            }));
        }
    }
}

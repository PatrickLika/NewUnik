using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Medarbej.Contract;

namespace Unik.WebApp.Pages.Medarbejder
{
    public class IndexModel : PageModel
    {
        private readonly IMedarbejderService _MedarbejderService;

        public IndexModel(IMedarbejderService MedarbejderService)
        {
            _MedarbejderService = MedarbejderService;
        }

        [BindProperty]
        public List<MedarbejderGetAllViewModel> IndexGetAllViewModel { get; set; } = new();

        //TODO lave delete og DETAILS loader begge lister + Tilføje til opgaver
        public async Task OnGet()
        {
            var businessModel = await _MedarbejderService.GetAll();

            businessModel.ToList().ForEach(dto => IndexGetAllViewModel.Add(new MedarbejderGetAllViewModel 
            {   Id = dto.Id, 
                Navn = dto.Navn, 
                Email = dto.Email, 
                Tlf = dto.Tlf,
                Titel = dto.Titel, 
                UserId = dto.UserId,
                KompetenceListe = dto.KompetenceListe
            }));
        }
    }
}

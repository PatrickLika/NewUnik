using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Kunde.Contract;

namespace Unik.WebApp.Pages.Kunde
{
    public class IndexModel : PageModel
    {
        private readonly IKundeService _kundeService;

        public IndexModel(IKundeService kundeService)
        {
            _kundeService = kundeService;
        }

        [BindProperty] public List<KundeIndexViewModel> KundeIndexViewModels { get; set; } = new();
        public async Task OnGet()
        {
            var liste = await _kundeService.GetAll();

            liste.ToList().ForEach(dto => KundeIndexViewModels.Add(new KundeIndexViewModel()
            {
                Email = dto.Email,
                Navn = dto.Navn,
                Id = dto.Id,
                Tlf = dto.Tlf,
                UserId = dto.UserId,
                RowVersion = dto.RowVersion,
                VirksomhedNavn = dto.VirksomhedNavn
            }));
        } 
    }



}

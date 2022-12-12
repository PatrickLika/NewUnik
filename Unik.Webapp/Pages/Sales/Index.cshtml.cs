using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Sales.Contract;

namespace Unik.WebApp.Pages.Sales
{
    public class IndexModel : PageModel
    {
        private readonly ISalesService _salesService;

        [BindProperty] public List<SalesIndexViewModel> IndexViewModel { get; set; } = new();

        public IndexModel(ISalesService salesService)
        {
            _salesService = salesService;
        }
        public async Task OnGet()
        {
            var salesListe = await _salesService.SalesGetAll();

            //salesListe.ToList().ForEach(dto => IndexViewModel.Add(new SalesIndexViewModel()
            //{
            //    Email = dto.Email,
            //    Id = dto.Id,
            //    Navn = dto.Navn,
            //    UserId = dto.UserId,
            //    Titel = dto.Titel,
            //    Tlf = dto.Tlf,
            //    Projekter = dto.ProjektListe
            //}));

            foreach (var item in salesListe.ToList())
            {
                var dto = new SalesIndexViewModel
                {
                    Email = item.Email,
                    Id = item.Id,
                    Navn = item.Navn,
                    Projekter = item.ProjektListe,
                    Titel = item.Titel,
                    Tlf = item.Tlf,
                    UserId = item.UserId
                };
                IndexViewModel.Add(dto);
            }
            //ah' forstå' d' ik' den udkommenterede burde virke ligesom den her, men det gør den ikke -.-
        }
    }
}

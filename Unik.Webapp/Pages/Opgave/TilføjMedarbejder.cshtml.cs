using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Opgave.Contract;
using Unik.WebApp.Infrastructure.Opgave.Contract.Dto;
using Unik.WebApp.Pages.Medarbejder;

namespace Unik.WebApp.Pages.Opgave
{
    public class TilføjMedarbejderModel : PageModel
    {
        private readonly IOpgaveService _opgaveService;
        private readonly IMedarbejderService _medarbejderService;

        [BindProperty] public OpgaveEditViewModel EditViewModel { get; set; }
        [BindProperty] public List<MedarbejderGetAllViewModel> MedarbejderViewModelListe { get; set; }
        public TilføjMedarbejderModel(IOpgaveService opgaveService, IMedarbejderService medarbejderService)
        {
            _opgaveService = opgaveService;
            _medarbejderService = medarbejderService;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            var opgaveDto = await _opgaveService.Get(id.Value);

            EditViewModel = new OpgaveEditViewModel()
            {
                Navn = opgaveDto.Navn,
                RowVersion = opgaveDto.RowVersion,
                BookingId = opgaveDto.BookingId.Value,
                Id = opgaveDto.Id,
                MedarbejderId = opgaveDto.MedarbejderId.Value,
                ProjektId = opgaveDto.ProjektId
            };

            var medarbejderListe = await _medarbejderService.GetAll();



            foreach (var dto in medarbejderListe.ToList())
            {
                MedarbejderViewModelListe.Add(new MedarbejderGetAllViewModel()
                {
                    RowVersion = dto.RowVersion,
                    Email = dto.Email,
                    Id = dto.Id,
                    KompetenceListe = dto.KompetenceListe,
                    Navn = dto.Navn,
                    Titel = dto.Titel,
                    Tlf = dto.Tlf,
                    UserId = dto.UserId
                });
            }

            //TODO jeg skal bruge en liste over medarbejdere baseret på opgave navnet.

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            var dto = new OpgaveEditRequestDto()
            {
                BookingId = EditViewModel.BookingId.Value,
                Id = EditViewModel.Id,
                MedarbejderId = EditViewModel.MedarbejderId.Value,
                Navn = EditViewModel.Navn,
                ProjektId = EditViewModel.ProjektId,
                RowVersion = EditViewModel.RowVersion
            };


            return RedirectToPage("./Index");
        }
    }
}

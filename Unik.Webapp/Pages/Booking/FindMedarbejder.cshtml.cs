using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Booking.Contract.Dto;
using Unik.WebApp.Infrastructure.Booking.Implementation;
using Unik.WebApp.Pages.Booking;

namespace Unik.Webapp.Pages.Booking
{
    public class FindMedarbejderModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public FindMedarbejderModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [BindProperty] public List<FindMedarbejderViewModel> FindMedarbejderViewModel { get; set; } = new();

        public async Task<IActionResult> OnGet(int opgaveId, string navn, int varighed)
        {
            if (opgaveId == null) return NotFound();

            var businessModel = await _bookingService.FindMedarbejder(navn);

            if (businessModel == null)
            {
                throw new Exception("Ingen Medarbejder kan sættes på opgaven");
            }

            businessModel.ToList().ForEach(dto => FindMedarbejderViewModel.Add(new FindMedarbejderViewModel
            {
                MedarbejderId = dto.MedarbejderId,
                StartDato = dto.startDato,
                SlutDato = dto.SlutDato,
                OpgaveId = opgaveId,
                Varighed = varighed

            }));

            return Page();
        }

    }
}

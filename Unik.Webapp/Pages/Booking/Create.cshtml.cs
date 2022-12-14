using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Booking.Contract.Dto;
using Unik.WebApp.Pages.Booking;

namespace Unik.Webapp.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public CreateModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [BindProperty] public BookingCreateViewModel OpgaveCreateViewModel { get; set; } = new();
        public async Task<IActionResult> OnGet(int MedarbejderId,DateTime SlutDato, int opgaveId, int varighed)
        {
            if (opgaveId == null) return NotFound();

            OpgaveCreateViewModel.MedarbejderId = MedarbejderId;
            OpgaveCreateViewModel.startDato = SlutDato.AddDays(1);
            OpgaveCreateViewModel.OpgaveId = opgaveId;
            OpgaveCreateViewModel.Varighed = varighed;
            OpgaveCreateViewModel.SlutDato = SlutDato.AddDays(varighed+1);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {

            return new RedirectToPageResult("./Index");
        }
    }
}

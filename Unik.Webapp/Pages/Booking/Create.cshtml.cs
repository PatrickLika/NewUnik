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
        [BindProperty] public BookingCreateViewModel BookingCreateViewModel { get; set; } = new();
        public async Task<IActionResult> OnGet(int medarbejderId,string slutDato, int opgaveId, int varighed)
        {
            if (opgaveId == null) return NotFound();

            BookingCreateViewModel.MedarbejderId = medarbejderId;
            BookingCreateViewModel.StartDato = DateTime.Parse(slutDato).AddDays(1);
            BookingCreateViewModel.OpgaveId = opgaveId;
            BookingCreateViewModel.Varighed = varighed;
            BookingCreateViewModel.SlutDato = DateTime.Parse(slutDato).AddDays(varighed + 1);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();


            var dto = new BookingCreateRequestDto()
            {
                OpgaveId = BookingCreateViewModel.OpgaveId,
                MedarbejderId = BookingCreateViewModel.MedarbejderId,
                startDato = BookingCreateViewModel.StartDato,
                SlutDato = BookingCreateViewModel.SlutDato,
            };

            try
            {
                await _bookingService.Create(dto);
            }

            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }

            return new RedirectToPageResult("./Index");
        }
    }
}

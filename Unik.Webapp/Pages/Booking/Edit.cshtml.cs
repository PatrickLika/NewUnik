using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Booking.Contract.Dto;

namespace Unik.WebApp.Pages.Booking
{
    public class EditModel : PageModel
    {
        private readonly IBookingService _bookingService;
        public EditModel(IBookingService bookingSerivce)
        {
            _bookingService = bookingSerivce;
        }
        [BindProperty] public BookingEditViewModel EditViewModel { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();
            var dto = await _bookingService.Get(id.Value);

            EditViewModel = new BookingEditViewModel
            {

            };
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            await _bookingService.Edit(new BookingEditRequestDto
            {

            });
            return RedirectToPage("./Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Booking.Contract;
using Unik.WebApp.Infrastructure.Booking.Contract.Dto;
using Unik.WebApp.Infrastructure.Booking.Implementation;

namespace Unik.WebApp.Pages.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly IBookingService _bookingService;
        public DeleteModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();
            await _bookingService.Delete(id.Value);
            return RedirectToPage("./Index");
        }
    }
}

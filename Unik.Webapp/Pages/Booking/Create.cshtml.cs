using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Booking.Contract.Dto;
using Unik.WebApp.Infrastructure.Booking.Implementation;
using Unik.WebApp.Pages.Booking;

namespace Unik.WebApp.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public CreateModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [BindProperty] public BookingCreateViewModel BookingCreateViewModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var BookingDto = new BookingCreateRequestDto()
            {
                
            };
            await _bookingService.Create(BookingDto);
            return new RedirectToPageResult("./index");
        }
    }
}

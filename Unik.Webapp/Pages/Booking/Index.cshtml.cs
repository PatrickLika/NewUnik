using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.Infrastructure.Booking.Contract.Dto;

namespace Unik.WebApp.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public IndexModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty] public List<BookingIndexViewModel> BookingIndexViewModels { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var liste = await _bookingService.GetAll();

            liste.ToList().ForEach(dto => BookingIndexViewModels.Add(new BookingIndexViewModel()
            {
                StartDato = dto.StartDato,
                SlutDato = dto.SlutDato,
            }));

            return Page();
        }
    }

}

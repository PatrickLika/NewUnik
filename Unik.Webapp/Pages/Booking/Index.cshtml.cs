using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.Webapp.Infrastructure.Booking.Contract.Dto;
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

        [BindProperty] public List<BookingIndexDto> BookingIndexViewModels { get; set; } = new();
        public async Task<IActionResult> OnGet()
        {
            var liste = await _bookingService.GetAll();

            liste.ToList().ForEach(dto => BookingIndexViewModels.Add(new BookingIndexDto
            {
                Id = dto.Id,
                StartDato = dto.StartDato,
                SlutDato = dto.SlutDato,
                MedarbejderNavn = dto.MedarbejderNavn,
                MedarbejderTitel = dto.MedarbejderTitel
            }));

            return Page();
        }
    }

}

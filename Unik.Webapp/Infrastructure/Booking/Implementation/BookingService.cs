using Unik.WebApp.Infrastructure.Booking.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Booking.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        async Task IBookingService.Create(BookingCreateRequestDto createDto)
        {
            await _httpClient.PostAsJsonAsync("api/Booking", createDto);
        }

        async Task IBookingService.Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Booking/{id}");
        }

        async Task IBookingService.Edit(BookingEditRequestDto editDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Booking", editDto);
            if (response.IsSuccessStatusCode) return;
            var messages = await response.Content.ReadAsStringAsync();
            throw new Exception(messages);
        }

        async Task<BookingResultDto> IBookingService.Get(int bookingId)
        {
            return await _httpClient.GetFromJsonAsync<BookingResultDto>($"api/Booking/{bookingId}");
        }

        async Task<IEnumerable<BookingResultDto>> IBookingService.GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BookingResultDto>>("api/Booking");
        }
    }
}

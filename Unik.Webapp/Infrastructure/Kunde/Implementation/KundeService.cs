using Unik.WebApp.Infrastructure.Kunde.Contract;
using Unik.WebApp.Infrastructure.Kunde.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Kunde.Implementation
{
    public class KundeService : IKundeService
    {
        private readonly HttpClient _httpClient;

        public KundeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task IKundeService.Create(KundeCreateRequestDto createDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Kunde", createDto);
            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();

            throw new Exception(message);
        }

        async Task<HttpResponseMessage> IKundeService.Delete(int id)
        {
            return await _httpClient.DeleteAsync($"api/Kunde/{id}");
        }


        async Task IKundeService.Edit(KundeEditRequestDto editDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Kunde", editDto);
            if (response.IsSuccessStatusCode) return;
            var messages = await response.Content.ReadAsStringAsync();
            throw new Exception(messages);
        }


        async Task<KundeGetQueryDto?> IKundeService.Get(int kundeId)
        {
            return await _httpClient.GetFromJsonAsync<KundeGetQueryDto>($"api/Kunde/{kundeId}");
        }

        async Task<IEnumerable<KundeGetAllQueryDto>?> IKundeService.GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<KundeGetAllQueryDto>>("api/Kunde");
        }

        async Task<KundeUserResultDto?> IKundeService.GetByUserId(string userId)
        {
            return await _httpClient.GetFromJsonAsync<KundeUserResultDto>($"api/Kunde/{userId}");
        }
    }
}

using System.Net.Http.Json;
using Unik.WebApp.Infrastructure.Kompetence.Contract;
using Unik.WebApp.Infrastructure.Kompetence.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Kompetence.Implementation
{
    public class kompetenceService : IkompetenceService
    {
        private readonly HttpClient _httpClient;

        public kompetenceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        async Task IkompetenceService.Create(KompetenceCreateRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/kompetence", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();

            throw new Exception(message);
        }
        async Task<IEnumerable<KompetenceQueryResultDto>?> IkompetenceService.getAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<KompetenceQueryResultDto>>("api/Kompetence");
        }

        async Task IkompetenceService.Edit(KompetenceEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/kompetence", dto);

            if(response.IsSuccessStatusCode) return;

            var messages = await response.Content.ReadAsStringAsync();
            throw new Exception(messages);
        }

        async Task<HttpResponseMessage> IkompetenceService.Delete(int id)
        {
            return await _httpClient.DeleteAsync($"api/kompetence/{id}");
        }

        async Task<KompetenceQueryResultDto?> IkompetenceService.Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<KompetenceQueryResultDto>($"api/Kompetence/{id}");
        }
    }
}

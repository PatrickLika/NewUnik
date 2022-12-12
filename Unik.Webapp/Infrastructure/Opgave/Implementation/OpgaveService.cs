using Unik.WebApp.Infrastructure.Opgave.Contract;
using Unik.WebApp.Infrastructure.Opgave.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Opgave.Implementation
{
    public class OpgaveService : IOpgaveService
    {
        private readonly HttpClient _httpClient;

        public OpgaveService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        async Task IOpgaveService.Create(OpgaveCreateRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/opgave", dto);

            if (response.IsSuccessStatusCode) return;

            var message = await response.Content.ReadAsStringAsync();

            throw new Exception(message);
        }

        async Task<HttpResponseMessage> IOpgaveService.Delete(int id)
        {
            return await _httpClient.DeleteAsync($"api/opgave/{id}");
        }

        async Task IOpgaveService.Edit(OpgaveEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/opgave", dto);

            if(response.IsSuccessStatusCode) return;

            var messages = await response.Content.ReadAsStringAsync();
            throw new Exception(messages);
        }

        async Task<OpgaveQueryResultDto?> IOpgaveService.Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<OpgaveQueryResultDto>($"api/opgave/{id}");
        }

        async Task<IEnumerable<OpgaveQueryResultDto>?> IOpgaveService.getAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OpgaveQueryResultDto>>("api/opgave");

        }
    }
}

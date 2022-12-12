using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Medarbej.Contract.Dto;
using Unik.WebApp.Infrastructure.Medarbejder.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Medarbej.Implementation
{
    public class MedarbejderService : IMedarbejderService
    {
        private readonly HttpClient _httpClient;

        public MedarbejderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        async Task IMedarbejderService.Create(MedarbejderCreateRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Medarbejder", dto);

            if (response.IsSuccessStatusCode) return;

            var messages = await response.Content.ReadAsStringAsync();
            throw new Exception(messages);

        }

        async Task IMedarbejderService.CreateMedarbejderKompetence(MedarbejderKompetenceCreateDto dto)
        {
            await _httpClient.PostAsJsonAsync("api/Medarbejder/Kompetence", dto);
        }

        async Task IMedarbejderService.Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Medarbejder/{id}");
        }

        async Task IMedarbejderService.Edit(MedarbejderEditRequestDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Medarbejder", dto);
            if (response.IsSuccessStatusCode) return;
            var messages = await response.Content.ReadAsStringAsync();
            throw new Exception(messages);

        }

        async Task<MedarbejderGetQueryDto> IMedarbejderService.Get(int id)
        {
           return await _httpClient.GetFromJsonAsync<MedarbejderGetQueryDto>($"api/Medarbejder/id/{id}");
        }

        async Task<IEnumerable<MedarbejderGetAllQueryDto>> IMedarbejderService.GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MedarbejderGetAllQueryDto>>("api/Medarbejder");
        }

        async Task<MedarbejderGetByUserIdDto> IMedarbejderService.GetByUserId(string userId)
        {
            return await _httpClient.GetFromJsonAsync<MedarbejderGetByUserIdDto>($"api/Medarbejder/{userId}");
        }
    }
}

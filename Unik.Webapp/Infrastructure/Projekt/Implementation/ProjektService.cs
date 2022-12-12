using Unik.WebApp.Infrastructure.Projekt.Contract;
using Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Projekt.Implementation;

public class ProjektService : IProjektService
{
    private readonly HttpClient _httpClient;

    public ProjektService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    async Task IProjektService.ProjektCreate(ProjektCreateRequestDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/Projekt", dto);
        if (response.IsSuccessStatusCode) return;
        var messages = await response.Content.ReadAsStringAsync();
        throw new Exception(messages);
    }

    async Task<HttpResponseMessage> IProjektService.ProjektDelete(int id)
    {
        return await _httpClient.DeleteAsync($"api/Projekt/{id}");
    }

    async Task IProjektService.ProjektEdit(ProjektEditRequestDto projektEditRequestDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Projekt", projektEditRequestDto);
        if (response.IsSuccessStatusCode) return;
        var messages = await response.Content.ReadAsStringAsync();
        throw new Exception(messages);
    }

    async Task<ProjektQueryResultDto?> IProjektService.ProjektGet(int id)
    {
        return await _httpClient.GetFromJsonAsync<ProjektQueryResultDto>($"api/Projekt/{id}");
    }

    async Task<IEnumerable<ProjektQueryResultDto>?> IProjektService.ProjektGetAll()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ProjektQueryResultDto>>($"api/Projekt");
    }
}
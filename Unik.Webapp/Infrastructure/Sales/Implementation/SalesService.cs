using Unik.WebApp.Infrastructure.Sales.Contract;
using Unik.WebApp.Infrastructure.Sales.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Sales.Implementation;

public class SalesService : ISalesService
{
    private readonly HttpClient _httpClient;

    public SalesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    //create
    async Task ISalesService.SalesCreate(SalesCreateRequestDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/Sales", dto);
        if (response.IsSuccessStatusCode) return;
        var messages = await response.Content.ReadAsStringAsync();
        throw new Exception(messages);
    }
    //Read
    async Task<SalesGetQueryDto?> ISalesService.SalesGet(int id)
    {
        return await _httpClient.GetFromJsonAsync<SalesGetQueryDto>($"api/Sales/{id}");
    }

    async Task<IEnumerable<SalesGetAllQueryDto>?> ISalesService.SalesGetAll()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<SalesGetAllQueryDto>>($"api/Sales");
    }
    //Edit
    async Task ISalesService.SalesEdit(SalesEditRequestDto salesEditRequestDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Sales", salesEditRequestDto);
        if (response.IsSuccessStatusCode) return;
        var messages = await response.Content.ReadAsStringAsync();
        throw new Exception(messages);
    }
    //delete
    async Task<HttpResponseMessage> ISalesService.SalesDelete(int id)
    {
        return await _httpClient.DeleteAsync($"api/Sales/{id}");
    }

}
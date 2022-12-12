using Unik.WebApp.Infrastructure.Projekt.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Projekt.Contract;

public interface IProjektService
{
    Task ProjektCreate(ProjektCreateRequestDto dto);
    Task ProjektEdit(ProjektEditRequestDto ProjektEditRequestDto);
    Task<ProjektQueryResultDto?> ProjektGet(int id);
    Task<IEnumerable<ProjektQueryResultDto>?> ProjektGetAll();
    Task<HttpResponseMessage> ProjektDelete(int id);
}
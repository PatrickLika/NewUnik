using Unik.WebApp.Infrastructure.Kompetence.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Kompetence.Contract
{
    public interface IkompetenceService
    {
        Task Create(KompetenceCreateRequestDto dto);
        Task <IEnumerable<KompetenceQueryResultDto>?> getAll();
        Task Edit(KompetenceEditRequestDto dto);
        Task<HttpResponseMessage> Delete(int id);
        Task<KompetenceQueryResultDto?> Get(int id);
    }
}

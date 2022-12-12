using Unik.WebApp.Infrastructure.Opgave.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Opgave.Contract
{
    public interface IOpgaveService
    {
        Task Create(OpgaveCreateRequestDto dto);
        Task <IEnumerable<OpgaveQueryResultDto>?> getAll();
        Task Edit(OpgaveEditRequestDto dto);
        Task<HttpResponseMessage> Delete(int id);
        Task<OpgaveQueryResultDto?> Get(int id);
    }
}

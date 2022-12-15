using Unik.WebApp.Infrastructure.Kunde.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Kunde.Contract;

public interface IKundeService
{
    Task Create(KundeCreateRequestDto dto);
    Task Edit(KundeEditRequestDto dto);
    Task<HttpResponseMessage> Delete(int id);
    Task<KundeGetQueryDto?> Get(int bookingId);
    Task<IEnumerable<KundeGetAllQueryDto>?> GetAll();

}


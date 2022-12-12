using Unik.WebApp.Infrastructure.Projekt.Contract.Dto;
using Unik.WebApp.Infrastructure.Sales.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Sales.Contract;

public interface ISalesService
{
    Task SalesCreate(SalesCreateRequestDto dto);
    Task SalesEdit(SalesEditRequestDto ProjektEditRequestDto);
    Task<SalesGetQueryDto?> SalesGet(int id);
    Task<IEnumerable<SalesGetAllQueryDto>?> SalesGetAll();
    Task<HttpResponseMessage> SalesDelete(int id);
}
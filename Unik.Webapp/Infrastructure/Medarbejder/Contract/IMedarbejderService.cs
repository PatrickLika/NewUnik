using Unik.WebApp.Infrastructure.Medarbej.Contract.Dto;
using Unik.WebApp.Infrastructure.Medarbejder.Contract.Dto;

namespace Unik.WebApp.Infrastructure.Medarbej.Contract
{
    public interface IMedarbejderService
    {
        Task Create(MedarbejderCreateRequestDto dto);
        Task Edit(MedarbejderEditRequestDto bmiEditRequestDto);
        Task<IEnumerable<MedarbejderGetAllQueryDto>> GetAll();
        Task<MedarbejderGetQueryDto> Get(int id);
        Task Delete(int id); 
        Task CreateMedarbejderKompetence(MedarbejderKompetenceCreateDto dto);
        Task <MedarbejderGetByUserIdDto> GetByUserId(string userId);
    }
}

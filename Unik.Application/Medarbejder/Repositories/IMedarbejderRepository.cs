using Unik.Applicaiton.Medarbejder.Commands;
using Unik.Applicaiton.Medarbejder.Query;
using Unik.Domain.Medarbejder.Model;

namespace Unik.Applicaiton.Medarbejder.Repositories
{
    public interface IMedarbejderRepository
    {
        void Create(MedarbejderEntity medarbejder);
        void Delete(int id);
        IEnumerable<MedarbejderGetAllQueryDto> GetAll();
        MedarbejderEntity Load(int id);
        void Update(MedarbejderEntity medarbejder);
        MedarbejderGetQueryDto Get(int userId);
        void CreateMedarbejderKompetence(MedarbejderKompetenceCreateDto dto);
        MedarbejderGetByUserIdDto GetByUserId(string userId);
    }
}

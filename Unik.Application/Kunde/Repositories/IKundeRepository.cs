using Unik.Applicaiton.Kunde.Query;
using Unik.Domain.Kunde.Model;

namespace Unik.Applicaiton.Kunde.Repositories
{
    public interface IKundeRepository
    {
        void Create(KundeEntity kunde);
        void Update(KundeEntity model);
        void Delete(int id);
        KundeEntity Load(int Id);
        KundeResultDto Get(int Id);
        IEnumerable<KundeResultDto> GetAll();
    }
}
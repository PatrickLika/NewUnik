using Unik.Applicaiton.Kompetence.Query;
using Unik.Domain.Kompetence.Model;

namespace Unik.Applicaiton.Kompetence.Repositories
{
    public interface IKompetenceRepository
    {
        void Create(KompetenceEntity kompetence);
        IEnumerable<KompetenceQueryResultDto> getAll();
        void Update(KompetenceEntity model);
        void Delete(int id);
        KompetenceEntity Load(int KompetenceId);
        KompetenceQueryResultDto Get(int id);
    }
}
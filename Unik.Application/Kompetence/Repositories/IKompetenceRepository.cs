using Unik.Applicaiton.Kompetence.Query;
using Unik.Application.Kompetence.Query.Implementation;
using Unik.Domain.Kompetence.Model;

namespace Unik.Applicaiton.Kompetence.Repositories
{
    public interface IKompetenceRepository
    {
        void Create(KompetenceEntity kompetence);
        IEnumerable<KompetenceGetAllQueryResultDto> getAll();
        void Update(KompetenceEntity model);
        void Delete(int id);
        KompetenceEntity Load(int KompetenceId);
        KompetenceGetQueryResultDto Get(int id);
    }
}
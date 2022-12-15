using Unik.Applicaiton.Kompetence.Repositories;
using Unik.Application.Kompetence.Query.Implementation;

namespace Unik.Applicaiton.Kompetence.Query.Implementation
{
    public class KompetenceGetQuery : iKompetenceGetQuery
    {
        private readonly IKompetenceRepository _repository;

        public KompetenceGetQuery(IKompetenceRepository repository)
        {
            _repository = repository;
        }

        KompetenceGetQueryResultDto iKompetenceGetQuery.Get(int id)
        {
            return _repository.Get(id);
        }
    }
}

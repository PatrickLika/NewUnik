using Unik.Applicaiton.Kompetence.Repositories;

namespace Unik.Applicaiton.Kompetence.Query.Implementation
{
    public class KompetenceGetQuery : iKompetenceGetQuery
    {
        private readonly IKompetenceRepository _repository;

        public KompetenceGetQuery(IKompetenceRepository repository)
        {
            _repository = repository;
        }

        KompetenceQueryResultDto iKompetenceGetQuery.Get(int id)
        {
            return _repository.Get(id);
        }
    }
}

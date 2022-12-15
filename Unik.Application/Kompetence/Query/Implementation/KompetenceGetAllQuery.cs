using Unik.Applicaiton.Kompetence.Repositories;

namespace Unik.Applicaiton.Kompetence.Query.Implementation
{
    public class KompetenceGetAllQuery : iKompetenceGetAllQuery

    {
        private readonly IKompetenceRepository _repository;

        public KompetenceGetAllQuery(IKompetenceRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<KompetenceGetAllQueryResultDto> iKompetenceGetAllQuery.GetAll()
        {
            return _repository.getAll();

        }


    }
}

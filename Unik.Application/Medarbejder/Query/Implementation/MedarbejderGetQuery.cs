using Unik.Applicaiton.Medarbejder.Repositories;

namespace Unik.Applicaiton.Medarbejder.Query.Implementation
{
    public class MedarbejderGetQuery : IMedarbejderGetQuery
    {
        private readonly IMedarbejderRepository _repository;

        public MedarbejderGetQuery(IMedarbejderRepository repository)
        {
            _repository = repository;
        }
        MedarbejderGetQueryDto IMedarbejderGetQuery.Get(int id)
        {
            return _repository.Get(id);
        }
    }
}

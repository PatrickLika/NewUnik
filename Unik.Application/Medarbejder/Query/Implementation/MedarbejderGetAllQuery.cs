using Unik.Applicaiton.Medarbejder.Repositories;

namespace Unik.Applicaiton.Medarbejder.Query.Implementation
{
    public class MedarbejderGetAllQuery : IMedarbejderGetAllQuery
    {
        private readonly IMedarbejderRepository _repository;

        public MedarbejderGetAllQuery(IMedarbejderRepository repository)
        {
            _repository = repository;
        }
        IEnumerable<MedarbejderGetAllQueryDto> IMedarbejderGetAllQuery.GetAll()
        {
            return _repository.GetAll();
        }
    }
}

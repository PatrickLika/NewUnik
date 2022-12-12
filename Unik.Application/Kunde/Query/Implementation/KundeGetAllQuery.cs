using Unik.Applicaiton.Kunde.Repositories;

namespace Unik.Applicaiton.Kunde.Query.Implementation
{
    public class KundeGetAllQuery : IKundeGetAllQuery
    {
        private readonly IKundeRepository _repository;

        public KundeGetAllQuery(IKundeRepository repository)
        {
            _repository = repository;
        }

        IEnumerable<KundeResultDto> IKundeGetAllQuery.GetAll()
        {
            return _repository.GetAll();
        }
    }
}

using Unik.Applicaiton.Opgave.Repositories;

namespace Unik.Applicaiton.Opgave.Queries.Implementation
{
    public class OpgaveGetAllQuery : IOpgaveGetAllQuery
    {
        private readonly IOpgaveRepository _repository;

        public OpgaveGetAllQuery(IOpgaveRepository repository)
        {
            _repository = repository;
        }
        IEnumerable<OpgaveQueryResultDto> IOpgaveGetAllQuery.GetAll()
        {
            return _repository.GetAll();
        }
    }
}

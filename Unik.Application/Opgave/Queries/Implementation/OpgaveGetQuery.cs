using Unik.Applicaiton.Opgave.Repositories;

namespace Unik.Applicaiton.Opgave.Queries.Implementation
{
    public class OpgaveGetQuery : IOpgaveGetQuery
    {

        private readonly IOpgaveRepository _repository;

        public OpgaveGetQuery(IOpgaveRepository repository)
        {
            _repository = repository;
        }
        OpgaveQueryResultDto IOpgaveGetQuery.Get(int id)
        {
            return _repository.Get(id);
        }
    }
}

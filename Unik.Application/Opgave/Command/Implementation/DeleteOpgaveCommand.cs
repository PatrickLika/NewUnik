using Unik.Applicaiton.Opgave.Repositories;

namespace Unik.Applicaiton.Opgave.Command.Implementation
{
    public class DeleteOpgaveCommand : IDeleteOpgaveCommand
    {
        private readonly IOpgaveRepository _repository;

        public DeleteOpgaveCommand(IOpgaveRepository repository)
        {
            _repository = repository;
        }
        void IDeleteOpgaveCommand.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}

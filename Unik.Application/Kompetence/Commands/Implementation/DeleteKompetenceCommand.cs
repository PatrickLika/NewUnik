using Unik.Applicaiton.Kompetence.Repositories;

namespace Unik.Applicaiton.Kompetence.Commands.Implementation
{
    public class DeleteKompetenceCommand : IDeleteKompetenceCommand
    {
        private readonly IKompetenceRepository _repository;
        public DeleteKompetenceCommand(IKompetenceRepository repository)
        {
            _repository = repository;
        }

        void IDeleteKompetenceCommand.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}

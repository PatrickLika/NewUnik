using Unik.Applicaiton.Medarbejder.Repositories;

namespace Unik.Applicaiton.Medarbejder.Commands.Implementation
{
    public class DeleteMedarbejderCommand: IDeleteMedarbejderCommand
    {
        private readonly IMedarbejderRepository _repository;

        public DeleteMedarbejderCommand(IMedarbejderRepository repository)
        {
            _repository = repository;
        }

        void IDeleteMedarbejderCommand.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}

using Unik.Applicaiton.Kunde.Repositories;

namespace Unik.Applicaiton.Kunde.Commands.Implementation
{
    public class DeleteKundeCommand : IDeleteKundeCommand
    {
        private readonly IKundeRepository _kundeRepository;
        public DeleteKundeCommand(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        void IDeleteKundeCommand.Delete(int id)
        {
            _kundeRepository.Delete(id);
        }
    }
}

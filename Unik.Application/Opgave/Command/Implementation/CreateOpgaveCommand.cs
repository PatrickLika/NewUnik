using Unik.Applicaiton.Opgave.Repositories;
using Unik.Domain.Opgave.DomainService;
using Unik.Domain.Opgave.Model;

namespace Unik.Applicaiton.Opgave.Command.Implementation
{
    public class CreateOpgaveCommand : ICreateOpgaveCommand
    {
        private readonly IOpgaveRepository _repository;
        private readonly IOpgaveDomainService _domainService;

        public CreateOpgaveCommand(IOpgaveRepository repository, IOpgaveDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }
        void ICreateOpgaveCommand.Create(OpgaveCreateRequestDto dto)
        {
            var opgave = new OpgaveEntity(_domainService,dto.Navn, dto.ProjektId, dto.Type);
            _repository.Create(opgave);
        }
    }
}

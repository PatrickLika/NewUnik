using Unik.Applicaiton.Kompetence.Repositories;
using Unik.Domain.Kompetence.Model;

namespace Unik.Applicaiton.Kompetence.Commands.Implementation
{
    public class CreateKompetenceCommand : ICreateKompetenceCommand
    {
        private readonly IKompetenceRepository _repository;

        public CreateKompetenceCommand(IKompetenceRepository repository)
        {
            _repository = repository;
        }

        void ICreateKompetenceCommand.Create(KompetenceCreateRequestDto dto)
        {
            var Kompetence = new KompetenceEntity(dto.Navn, dto.Type);

            _repository.Create(Kompetence);
        }
    }
}

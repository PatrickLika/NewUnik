using Unik.Applicaiton.Kunde.Repositories;
using Unik.Domain.Kunde.Model;

namespace Unik.Applicaiton.Kunde.Commands.Implementation
{
    public class CreateKundeCommand : ICreateKundeCommand
    {
        private readonly IKundeRepository _kundeRepository;

        public CreateKundeCommand(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        void ICreateKundeCommand.Create(KundeCreateRequestDto dto)
        {
            var kunde = new KundeEntity(
                dto.Navn, 
                dto.VirksomhedsNavn,
                dto.Tlf,
                dto.Email,
                dto.UserId
            );

            _kundeRepository.Create(kunde);
        }
    }
}

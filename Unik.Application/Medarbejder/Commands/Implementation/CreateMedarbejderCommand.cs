using Unik.Applicaiton.Medarbejder.Repositories;
using Unik.Domain.Medarbejder.Model;

namespace Unik.Applicaiton.Medarbejder.Commands.Implementation
{
    public class CreateMedarbejderCommand : ICreateMedarbejderCommand
    {
        private readonly IMedarbejderRepository _medarbejderRepository;

        public CreateMedarbejderCommand(IMedarbejderRepository medarbejderRepository)
        {
            _medarbejderRepository = medarbejderRepository;
        }

        void ICreateMedarbejderCommand.Create(MedarbejderCreateRequestDto requestDto)
        {
            var medarbejder = new MedarbejderEntity(requestDto.Navn, requestDto.Email, requestDto.Tlf,requestDto.Titel, requestDto.UserId);
            _medarbejderRepository.Create(medarbejder);

        }

    }
}

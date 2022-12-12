using Unik.Applicaiton.Kunde.Repositories;

namespace Unik.Applicaiton.Kunde.Commands.Implementation
{
    public class EditKundeCommand : IEditKundeCommand
    {
        private readonly IKundeRepository _kundeRepository;

        public EditKundeCommand(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }
        void IEditKundeCommand.Edit(KundeEditRequestDto requestDto)
        {
            var model = _kundeRepository.Load(requestDto.Id);

            model.Edit(

                requestDto.Id,
                requestDto.Navn,
                requestDto.VirksomhedsNavn,
                requestDto.Tlf,
                requestDto.RowVersion

            );

            _kundeRepository.Update(model);
        }
    }
}

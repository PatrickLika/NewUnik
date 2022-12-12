using Unik.Applicaiton.Medarbejder.Repositories;

namespace Unik.Applicaiton.Medarbejder.Commands.Implementation
{
    public class EditMedarbejderCommand: IEditMedarbejderCommand
    {
        private readonly IMedarbejderRepository _medarbejderRepository;

        public EditMedarbejderCommand(IMedarbejderRepository medarbejderRepository)
        {
            _medarbejderRepository = medarbejderRepository;
        }


        void IEditMedarbejderCommand.Edit(MedarbejderEditRequestDto requestDto)
        {

            //Read
            var model = _medarbejderRepository.Load(requestDto.Id);

            //Doit
            model.Edit(requestDto.Navn, requestDto.Email, requestDto.Tlf, requestDto.Titel, requestDto.RowVersion);

            //Save
            _medarbejderRepository.Update(model);

        }
    }
}

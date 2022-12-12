using Unik.Applicaiton.Kompetence.Repositories;

namespace Unik.Applicaiton.Kompetence.Commands.Implementation
{
    public class EditKompetenceCommand : IEditKompetenceCommand
    {
        private readonly IKompetenceRepository _repository;

        public EditKompetenceCommand(IKompetenceRepository repository)
        {
            _repository = repository;
        }
        void IEditKompetenceCommand.Edit(KompetenceEditRequestDto requestDto)
        {
            var model = _repository.Load(requestDto.Id);

            model.Edit(requestDto.Navn, requestDto.Type, requestDto.RowVersion, requestDto.MedarbejderListe);

            _repository.Update(model);

            
        }
    }
}

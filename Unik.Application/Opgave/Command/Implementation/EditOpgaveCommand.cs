using Unik.Applicaiton.Opgave.Repositories;

namespace Unik.Applicaiton.Opgave.Command.Implementation
{
    public class EditOpgaveCommand : IEditOpgaveCommand
    {
        private readonly IOpgaveRepository _repository;

        public EditOpgaveCommand(IOpgaveRepository repository)
        {
            _repository = repository;
        }
        void IEditOpgaveCommand.Edit(OpgaveEditRequestDto dto)
        {
            var model = _repository.Load(dto.Id);
            
            model.Edit(dto.Navn, dto.ProjektId, dto.RowVersion, dto.MedarbejderId, dto.BookingId, dto.Type);

            _repository.Update(model);
        }
    }
}

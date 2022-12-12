using Unik.Applicaiton.Sales.Repositories;

namespace Unik.Applicaiton.Sales.Commands.Implementation
{
    public class EditSalesCommand: IEditSalesCommand
    {
        private readonly ISalesRepository _salesRepository;

        public EditSalesCommand(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }


        void IEditSalesCommand.Edit(SalesEditRequestDto requestDto)
        {

            //Read
            var model = _salesRepository.Load(requestDto.Id);

            //Doit
            model.Edit(requestDto.Navn, requestDto.Email, requestDto.Tlf, requestDto.Titel,requestDto.RowVersion);

            //Save
            _salesRepository.Update(model);

        }
    }
}

using Unik.Applicaiton.Sales.Repositories;
using Unik.Domain.Sales.Model;

namespace Unik.Applicaiton.Sales.Commands.Implementation
{
    public class CreateSalesCommand: ICreateSalesCommand
    {
        private readonly ISalesRepository _salesRepository;

        public CreateSalesCommand(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        void ICreateSalesCommand.Create(SalesCreateRequestDto requestDto)
        {
            var sales = new SalesEntity(requestDto.Navn, requestDto.Email, requestDto.Tlf, requestDto.Titel, requestDto.UserId);

            _salesRepository.Create(sales);

        }

    }
}

using Unik.Applicaiton.Sales.Repositories;

namespace Unik.Applicaiton.Sales.Commands.Implementation
{
    public class DeleteSalesCommand: IDeleteSalesCommand
    {
        private readonly ISalesRepository _repository;

        public DeleteSalesCommand(ISalesRepository repository)
        {
            _repository = repository;
        }

        void IDeleteSalesCommand.Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}

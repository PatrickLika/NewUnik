using Unik.Applicaiton.Medarbejder.Repositories;
using Unik.Applicaiton.Sales.Repositories;

namespace Unik.Applicaiton.Sales.Query.Implementation
{
    public class SalesGetAllQuery : ISalesGetAllQuery
    {
        private readonly ISalesRepository _repository;

        public SalesGetAllQuery(ISalesRepository repository)
        {
            _repository = repository;
        }
        IEnumerable<SalesGetAllQueryDto> ISalesGetAllQuery.GetAll()
        {
            return _repository.GetAll();
        }
    }
}

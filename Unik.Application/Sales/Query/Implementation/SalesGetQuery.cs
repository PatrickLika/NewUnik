using Unik.Applicaiton.Sales.Repositories;

namespace Unik.Applicaiton.Sales.Query.Implementation
{
    public class SalesGetQuery : ISalesGetQuery
    {
        private readonly ISalesRepository _repository;

        public SalesGetQuery(ISalesRepository repository)
        {
            _repository = repository;
        }
        SalesGetQueryDto ISalesGetQuery.Get(int id)
        {
            return _repository.Get(id);
        }
    }
}

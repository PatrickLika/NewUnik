using Unik.Applicaiton.Sales.Query;
using Unik.Domain.Sales.Model;

namespace Unik.Applicaiton.Sales.Repositories
{
    public interface ISalesRepository
    {
        void Create(SalesEntity medarbejder);
        void Delete(int id);
        IEnumerable<SalesGetAllQueryDto> GetAll();
        SalesEntity Load(int id);
        void Update(SalesEntity medarbejder);
        SalesGetQueryDto Get(int id);
    }
}

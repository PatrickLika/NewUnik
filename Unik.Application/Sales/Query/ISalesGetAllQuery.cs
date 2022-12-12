namespace Unik.Applicaiton.Sales.Query
{
    public interface ISalesGetAllQuery
    {
        IEnumerable<SalesGetAllQueryDto> GetAll();
    }
}

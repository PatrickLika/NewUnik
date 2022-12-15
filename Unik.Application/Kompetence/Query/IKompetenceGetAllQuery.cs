using Unik.Application.Kompetence.Query.Implementation;

namespace Unik.Applicaiton.Kompetence.Query
{
    public interface iKompetenceGetAllQuery
    {
        IEnumerable<KompetenceGetAllQueryResultDto> GetAll();
    }
}

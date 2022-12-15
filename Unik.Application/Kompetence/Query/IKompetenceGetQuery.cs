using Unik.Application.Kompetence.Query.Implementation;

namespace Unik.Applicaiton.Kompetence.Query
{
    public interface iKompetenceGetQuery
    {
        KompetenceGetQueryResultDto Get(int id);
    }
}

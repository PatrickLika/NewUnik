using Unik.Applicaiton.Projekt.Repositories;

namespace Unik.Applicaiton.Projekt.Queries.Implementation;

public class ProjektGetAllQuery : IProjektGetAllQuery
{
    private readonly IProjektRepositories _db;

    public ProjektGetAllQuery(IProjektRepositories db)
    {
        _db = db;
    }
    IEnumerable<ProjektQueryResultDto> IProjektGetAllQuery.GetAll()
    {
        return _db.GetAll();
    }
}
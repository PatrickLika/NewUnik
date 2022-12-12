using Unik.Applicaiton.Projekt.Repositories;

namespace Unik.Applicaiton.Projekt.Queries.Implementation;

public class ProjektGetQuery : IProjektGetQuery
{
    private readonly IProjektRepositories _db;

    public ProjektGetQuery(IProjektRepositories db)
    {
        _db = db;
    }

    ProjektQueryResultDto IProjektGetQuery.Get(int projektId)
    {
        return _db.Get(projektId);
    }
}
using Unik.Applicaiton.Kunde.Repositories;

namespace Unik.Applicaiton.Kunde.Query.Implementation;

public class KundeGetQuery : IKundeGetQuery
{
    private readonly IKundeRepository _kundeRepository;

    public KundeGetQuery(IKundeRepository kundeRepository)
    {
        _kundeRepository = kundeRepository;
    }

    KundeResultDto IKundeGetQuery.Get(int id)
    {
        return _kundeRepository.Get(id);
    }
}
using Unik.Applicaiton.Projekt.Queries;
using Unik.Domain.Projekt.Model;

namespace Unik.Applicaiton.Projekt.Repositories;

public interface IProjektRepositories
{
    void Add(ProjektEntity projekt);
    ProjektEntity Load(int id);
    void Update(ProjektEntity model);
    ProjektQueryResultDto Get(int id);

    IEnumerable<ProjektQueryResultDto> GetAll();
    void Delete(int id);
}
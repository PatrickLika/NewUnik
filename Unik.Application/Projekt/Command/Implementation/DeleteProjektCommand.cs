using Unik.Applicaiton.Projekt.Repositories;

namespace Unik.Applicaiton.Projekt.Command.Implementation;

public class DeleteProjektCommand : IDeleteProjektCommand
{
    private readonly IProjektRepositories _db;

    public DeleteProjektCommand(IProjektRepositories _db)
    {
        this._db = _db;
    }

    void IDeleteProjektCommand.Delete(int dto)
    {
        _db.Delete(dto);
    }
}
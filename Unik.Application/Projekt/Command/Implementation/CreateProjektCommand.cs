using Unik.Applicaiton.Projekt.Repositories;
using Unik.Domain.Projekt.Model;

namespace Unik.Applicaiton.Projekt.Command.Implementation;

public class CreateProjektCommand : ICreateProjektCommand
{
    private readonly IProjektRepositories _db;

    public CreateProjektCommand(IProjektRepositories _db)
    {
        this._db = _db;
    }
    void ICreateProjektCommand.Create(ProjektCreateRequestDto dto)
    {
        var entity = new ProjektEntity(dto.Noter, dto.KundeId ,dto.SalesId, dto.AntalBoliger);

        _db.Add(entity);
    }
}
using Unik.Applicaiton.Projekt.Repositories;

namespace Unik.Applicaiton.Projekt.Command.Implementation;

public class EditProjektCommand : IEditProjektCommand
{
    private readonly IProjektRepositories _db;

    public EditProjektCommand(IProjektRepositories db)
    {
        _db = db;
    }
    void IEditProjektCommand.Edit(ProjektEditRequestDto dto)
    {

        var model = _db.Load(dto.id);


        model.Edit(dto.Noter, dto.RowVersion, dto.KundeId, dto.SælgerId, dto.AntalBoliger);

        _db.Update(model);
    }
}
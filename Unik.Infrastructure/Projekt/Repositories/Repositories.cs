using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Projekt.Queries;
using Unik.Applicaiton.Projekt.Repositories;
using Unik.Crosscut.Dto;
using Unik.Domain.Opgave.Model;
using Unik.Domain.Projekt.Model;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Projekt.Repositories;

public class Repositories : IProjektRepositories
{
    private readonly UnikContext _db;
    public Repositories(UnikContext db)
    {
        _db = db;
    }
    void IProjektRepositories.Add(ProjektEntity projekt)
    {

        _db.Add(projekt);
        _db.SaveChanges();
    }

    void IProjektRepositories.Delete(int id)
    {
        var model = _db.ProjektEntities.SingleOrDefault(a => a.Id == id);
        if (model == null) throw new Exception("Projektet findes ikke i databasen");

        _db.ProjektEntities.Remove(model);
        _db.SaveChanges();
    }

    ProjektQueryResultDto IProjektRepositories.Get(int id)
    {
        var projekt = _db.ProjektEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);
        if (projekt == null) throw new Exception("Projektet findes ikke i databasen");

        return new ProjektQueryResultDto
        {
            RowVersion = projekt.RowVersion,
            Id = projekt.Id,
            Noter = projekt.Noter,
            kundeID = projekt.KundeId,
            SalesId = projekt.SalesId,
            AntalBoliger = projekt.AntalBoliger,
            OpgaveListe = FillOpgaveListe(projekt.Opgaver)
        };
    }

    private List<OpgaveEntityDto> FillOpgaveListe(List<OpgaveEntity>? opgaveListe)
    {
        if (opgaveListe is null) throw new Exception("Kunne ikke finde medarbejder");

        var res = new List<OpgaveEntityDto>();
        opgaveListe.ForEach(m => res.Add(new OpgaveEntityDto
        {
            Navn = m.Navn,
            Type = m.Type,
            Varighed = m.Varighed,
        }));

        return res;
    }
    IEnumerable<ProjektQueryResultDto> IProjektRepositories.GetAll()
    {
        foreach (var dbEntity in _db.ProjektEntities.AsNoTracking().ToList())

            yield return new ProjektQueryResultDto
            {
                RowVersion = dbEntity.RowVersion,
                Id = dbEntity.Id,
                Noter = dbEntity.Noter,
                SalesId = dbEntity.SalesId,
                kundeID = dbEntity.KundeId,
                AntalBoliger = dbEntity.AntalBoliger
            };
    }

    ProjektEntity IProjektRepositories.Load(int id)
    {
        var dbEntity = _db.ProjektEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);
        if (dbEntity == null) throw new Exception("projektet findes ikke i databasen");
        return dbEntity;
    }

    void IProjektRepositories.Update(ProjektEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }
}
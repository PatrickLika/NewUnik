using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Sales.Query;
using Unik.Applicaiton.Sales.Repositories;
using Unik.Crosscut.Dto;
using Unik.Domain.Medarbejder.Model;
using Unik.Domain.Projekt.Model;
using Unik.Domain.Sales.Model;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Sales.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly UnikContext _db;

        public SalesRepository(UnikContext db)
        {
            _db = db;
        }



        void ISalesRepository.Create(SalesEntity sales)
        {
            _db.Add(sales);
            _db.SaveChanges();
        }




        IEnumerable<SalesGetAllQueryDto> ISalesRepository.GetAll()
        {

            foreach (var entity in _db.SalesEntities.AsNoTracking().ToList())
            {
                yield return new SalesGetAllQueryDto
                {
                    Id = entity.Id,
                    Titel = entity.Titel,
                    Navn = entity.Navn,
                    Email = entity.Email,
                    Tlf = entity.Tlf,
                    RowVersion = entity.RowVersion,
                    UserId = entity.UserId
                };
            }


        }

        void ISalesRepository.Delete(int id)
        {

            var model = _db.SalesEntities.SingleOrDefault(a => a.Id == id);
            if (model == null) throw new Exception("Sælger findes ikke i databasen");

            _db.SalesEntities.Remove(model);
            _db.SaveChanges();

        }



        SalesEntity ISalesRepository.Load(int id)
        {
            var dbEntity = _db.SalesEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (dbEntity == null) throw new Exception($"Medarbehder med Id:{id} findes ikke");
            return dbEntity;


        }



        void ISalesRepository.Update(SalesEntity model)
        {
            _db.Update(model);
            _db.SaveChanges();
        }

        SalesGetQueryDto ISalesRepository.Get(int id)
        {
            var dbEntity = _db.SalesEntities.AsNoTracking().Include(a => a.ProjektListe).FirstOrDefault(a => a.Id == id);
            if (dbEntity == null) throw new Exception("Sælger findes ikke i databasen");

            return new SalesGetQueryDto
            { Id = dbEntity.Id,
                Navn = dbEntity.Navn,
                Email = dbEntity.Email,
                Tlf = dbEntity.Tlf, 
                Titel = dbEntity.Titel,
                RowVersion = dbEntity.RowVersion,
                UserId = dbEntity.UserId,
                ProjektListe = FillProjektListe(dbEntity.ProjektListe)
            };
        
        }
        private List<ProjektEntityDto> FillProjektListe(List<ProjektEntity>? projektListe)
        {
            if (projektListe is null) throw new Exception("Kunne ikke finde medarbejder");

            var res = new List<ProjektEntityDto>();
            projektListe.ForEach(m => res.Add(new ProjektEntityDto
            {
                AntalBoliger = m.AntalBoliger,
                Noter = m.Noter,
            }));

            return res;
        }

    }
}

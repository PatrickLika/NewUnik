using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Kompetence.Query;
using Unik.Applicaiton.Kompetence.Repositories;
using Unik.Application.Kompetence.Query.Implementation;
using Unik.Crosscut.Dto;
using Unik.Domain.Kompetence.Model;
using Unik.Domain.Medarbejder.Model;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Kompetence.Repositories
{
    public class KompetenceRepository : IKompetenceRepository
    {
        private readonly UnikContext _db;

        public KompetenceRepository(UnikContext db)
        {
            _db = db;
        }
        void IKompetenceRepository.Create(KompetenceEntity kompetence)
        {
            _db.Add(kompetence);
            _db.SaveChanges();
        }

        void IKompetenceRepository.Delete(int id)
        {
            var model = _db.KompetenceEntities.SingleOrDefault(x => x.Id == id);
            if (model == null) throw new Exception($"Kompetence med {id} findes ikke");
            _db.Remove(model);
            _db.SaveChanges();
        }

        KompetenceGetQueryResultDto IKompetenceRepository.Get(int id)
        {

            var kompetence = _db.KompetenceEntities.AsNoTracking().Include(a => a.MedarbejderListe).FirstOrDefault(a => a.Id == id);
            if (kompetence == null) throw new Exception("Booking findes ikke i databasen");

            return new KompetenceGetQueryResultDto
            {
                Navn = kompetence.Navn,
                Type = kompetence.Type,
                Id = kompetence.Id,
                MedarbejderListe = FillMedarbejderListe(kompetence.MedarbejderListe)
            };

        }

        private List<MedarbejderEntityDto> FillMedarbejderListe(List<MedarbejderEntity>? medarbejderListe)
        {
            if (medarbejderListe is null) throw new Exception("Kunne ikke finde medarbejder");

            var res = new List<MedarbejderEntityDto>();
            medarbejderListe.ForEach(m => res.Add(new MedarbejderEntityDto
            {
                Navn = m.Navn,
            }));

            return res;
        }

        IEnumerable<KompetenceGetAllQueryResultDto> IKompetenceRepository.getAll()
        {
            foreach (var entity in _db.KompetenceEntities.AsNoTracking().ToList())
            {
                yield return new KompetenceGetAllQueryResultDto
                {
                    Id = entity.Id,
                    Type = entity.Type,
                    Navn = entity.Navn,
                };

            }

        }
        KompetenceEntity IKompetenceRepository.Load(int KompetenceId)
        {

            var dbEntity = _db.KompetenceEntities.AsNoTracking().FirstOrDefault(x => x.Id == KompetenceId);
            if (dbEntity == null) throw new Exception($"Kompetence med Id:{KompetenceId} findes ikke");
            return dbEntity;

        }

        void IKompetenceRepository.Update(KompetenceEntity model)
        {
            _db.KompetenceEntities.Update(model);
            _db.SaveChanges();
        }
    }
}

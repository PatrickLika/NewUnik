using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Kompetence.Query;
using Unik.Applicaiton.Kompetence.Repositories;
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

        KompetenceQueryResultDto IKompetenceRepository.Get(int id)
        {

            var Kompetence = _db.KompetenceEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);
            var medarbejderListe = _db.KompetenceEntities.AsNoTracking().Where(a => a.Id == id).SelectMany(b => b.MedarbejderListe).ToList();

            if(Kompetence == null) throw new Exception($"Kompetence med {id} findes ikke");

            return new KompetenceQueryResultDto 
            {       Id = Kompetence.Id,
                    Navn = Kompetence.Navn,
                    Type = Kompetence.Type,
                    RowVersion = Kompetence.RowVersion,
                    MedarbejderListe = medarbejderListe
            };
        }


        IEnumerable<KompetenceQueryResultDto> IKompetenceRepository.getAll()
        {
            foreach (var entity in _db.KompetenceEntities.AsNoTracking().ToList())
            {
                var medarbejderListe = _db.KompetenceEntities.AsNoTracking().SelectMany(a => a.MedarbejderListe).ToList();

                yield return new KompetenceQueryResultDto
                {
                    Id = entity.Id,
                    Type = entity.Type,
                    Navn = entity.Navn,
                    MedarbejderListe = medarbejderListe
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

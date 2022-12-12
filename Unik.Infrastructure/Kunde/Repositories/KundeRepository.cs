using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Kunde.Query;
using Unik.Applicaiton.Kunde.Repositories;
using Unik.Domain.Kunde.Model;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Kunde.Repositories
{
    public class KundeRepository : IKundeRepository
    {
        private readonly UnikContext _db;
        public KundeRepository(UnikContext db)
        {
            _db = db;
        }

        void IKundeRepository.Create(KundeEntity kunde)
        {
            _db.Add(kunde);
            _db.SaveChanges();
        }

        void IKundeRepository.Delete(int id)
        {
            var model = _db.KundeEntities.SingleOrDefault(a => a.Id == id);
            if (model == null) throw new Exception($"Kunde med {id} findes ikke i databasen");

            _db.KundeEntities.Remove(model);
            _db.SaveChanges();
        }

        KundeResultDto IKundeRepository.Get(int kundeId)
        {
            var dbEntity = _db.KundeEntities.AsNoTracking().FirstOrDefault(a => a.Id == kundeId);
            if (dbEntity == null) throw new Exception("Kunde findes ikke i databasen");

            return new KundeResultDto
                {
                    Id = dbEntity.Id,
                    Navn = dbEntity.Navn,
                    VirksomhedNavn = dbEntity.VirksomhedNavn,
                    Email = dbEntity.Email,
                    Tlf = dbEntity.Tlf,
                    RowVersion = dbEntity.RowVersion,
                    UserId = dbEntity.UserId
                };
        }
        IEnumerable<KundeResultDto> IKundeRepository.GetAll()
        {
            foreach (var dbEntity in _db.KundeEntities.AsNoTracking().ToList())
            {
                yield return new KundeResultDto
                {
                    Id = dbEntity.Id,
                    Navn = dbEntity.Navn,
                    VirksomhedNavn = dbEntity.VirksomhedNavn,
                    Email = dbEntity.Email,
                    Tlf = dbEntity.Tlf,
                    RowVersion = dbEntity.RowVersion,
                    UserId = dbEntity.UserId
                };
            }
        }

        KundeEntity IKundeRepository.Load(int kundeId)
        {
            var dbEntity = _db.KundeEntities.AsNoTracking().FirstOrDefault(x => x.Id == kundeId);
            if (dbEntity == null) throw new Exception($"Kunde med Id:{kundeId} findes ikke");
            return dbEntity;
        }

        void IKundeRepository.Update(KundeEntity model)
        {
            _db.Update(model);
            _db.SaveChanges();
        }
    }
}

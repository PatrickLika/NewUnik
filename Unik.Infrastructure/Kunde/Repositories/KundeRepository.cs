using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Unik.Applicaiton.Kunde.Query;
using Unik.Applicaiton.Kunde.Repositories;
using Unik.Application.Kunde.Query;
using Unik.Crosscut.Dto;
using Unik.Domain.Booking.Model;
using Unik.Domain.Kunde.Model;
using Unik.Domain.Opgave.Model;
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

        KundeUserResultDto IKundeRepository.GetUser(string userId)
        {

            var kunde = _db.KundeEntities.AsNoTracking().Include(a => a.Projekt).ThenInclude(a => a.Opgaver).FirstOrDefault(a => a.UserId == userId);

            

            if (kunde == null) throw new Exception($"kunde findes ikke");

           return new KundeUserResultDto
            {
               VirksomhedNavn = kunde.VirksomhedNavn,
               OpgaveListe = FillOpgaveListe(kunde.Projekt.Opgaver)
            };

           
        }

        private List<OpgaveEntityDto> FillOpgaveListe(List<OpgaveEntity>? opgaveListe)
        {
            if (opgaveListe is null) throw new Exception("Kunne ikke finde medarbejder");

            var res = new List<OpgaveEntityDto>();
            opgaveListe.ForEach(m => res.Add(new OpgaveEntityDto
            {
                Id = m.Id,
                Navn = m.Navn,
                Varighed = m.Varighed,
                Type = m.Type

            }));
            return res;
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

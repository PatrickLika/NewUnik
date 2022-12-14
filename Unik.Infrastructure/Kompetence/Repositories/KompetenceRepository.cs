using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Kompetence.Query;
using Unik.Applicaiton.Kompetence.Repositories;
using Unik.Application.Booking.Queries.Implementation;
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

        KompetenceQueryResultDto IKompetenceRepository.Get(int id)
        {

            //var bookingliste = _db.MedarbejderEntities.Include(a => a.BookingListe).ThenInclude(a => a.OpgaveId).SelectMany(
            //    a => a.BookingListe, (entity, bookingEntity) => new BookingGetAllResulstDto

            var test = _db.MedarbejderEntities.Include(a => a.KompetenceListe).SelectMany(
                a => a.KompetenceListe, (entity, kompetenceEntity) => new KompetenceQueryResultDto
                {
                    Id = entity.Id,
                    Navn = entity.Navn,
                    Type = kompetenceEntity.Type,
                    RowVersion = kompetenceEntity.RowVersion,
                    UserId = entity.UserId,
                    //MedarbejderListe = her mangler liste.
                });

            throw new NotImplementedException();

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
                   // MedarbejderListe = medarbejderListe
                };

            }

            throw new NotImplementedException();

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

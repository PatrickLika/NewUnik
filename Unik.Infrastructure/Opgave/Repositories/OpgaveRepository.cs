using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Opgave.Queries;
using Unik.Applicaiton.Opgave.Repositories;
using Unik.Domain.Opgave.Model;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Opgave.Repositories
{
    public class OpgaveRepository : IOpgaveRepository
    {
        private readonly UnikContext _db;

        public OpgaveRepository(UnikContext db)
        {
            _db = db;
        }
        void IOpgaveRepository.Create(OpgaveEntity model)
        {
            _db.Add(model);
            _db.SaveChanges();
        }

        void IOpgaveRepository.Delete(int id)
        {
            var model = _db.OpgaveEntities.SingleOrDefault(x => x.Id == id);
            if (model == null) throw new Exception($"Opgave med {id} findes ikke");
            _db.Remove(model);
            _db.SaveChanges();
        }

        OpgaveQueryResultDto IOpgaveRepository.Get(int id)
        {
            var dbEntity = _db.OpgaveEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (dbEntity == null) throw new Exception($"Opgave med {id} findes ikke");

            return new OpgaveQueryResultDto
            {
                Id = dbEntity.Id,
                Navn = dbEntity.Navn,
                ProjektId = dbEntity.ProjektId,
                Type = dbEntity.Type,
                BookingId = dbEntity.BookingId,
                MedarbejderId = dbEntity.MedarbejderId,
                Varighed = dbEntity.Varighed,
                RowVersion = dbEntity.RowVersion
            };
        }

        IEnumerable<OpgaveQueryResultDto> IOpgaveRepository.GetAll()
        {

            foreach (var entity in _db.OpgaveEntities.AsNoTracking().ToList())
            {
                yield return new OpgaveQueryResultDto
                {
                    Id = entity.Id,
                    Navn = entity.Navn,
                    RowVersion = entity.RowVersion,
                    ProjektId = entity.ProjektId,
                    BookingId = entity.BookingId,
                    MedarbejderId = entity.MedarbejderId,
                    Varighed = entity.Varighed,
                    Type = entity.Type
                };
            }
        }

        OpgaveEntity IOpgaveRepository.Load(int OpgaveId)
        {
            var dbEntity = _db.OpgaveEntities.AsNoTracking().FirstOrDefault(x => x.Id == OpgaveId);
            if (dbEntity == null) throw new Exception($"Opgave med Id:{OpgaveId} findes ikke");
            return dbEntity;
        }

        void IOpgaveRepository.Update(OpgaveEntity model)
        {
            _db.OpgaveEntities.Update(model);
            _db.SaveChanges();
        }
    }
}

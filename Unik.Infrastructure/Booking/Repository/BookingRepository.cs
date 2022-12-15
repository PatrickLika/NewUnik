using Microsoft.EntityFrameworkCore;
using Unik.Applicaiton.Booking.Queries;
using Unik.Applicaiton.Booking.Repositories;
using Unik.Applicaiton.Kompetence.Query;
using Unik.Application.Booking.Queries;
using Unik.Domain.Booking.Model;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Booking.Repository;

public class BoookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly UnikContext _db;

        public BookingRepository(UnikContext db)
        {
            _db = db;
        }
        void IBookingRepository.Create(BookingEntity booking)
        {
            _db.BookingEntities.Add(booking);
            _db.SaveChanges();
        }
        void IBookingRepository.Update(BookingEntity model)
        {
            _db.BookingEntities.Update(model);
        }

        void IBookingRepository.Delete(int id)
        {
            var model = _db.BookingEntities.SingleOrDefault(a => a.Id == id);

            _db.BookingEntities.Remove(model);

            if (model == null) throw new Exception("Bookingen findes ikke i databasen");

            _db.SaveChanges();
        }
        BookingEntity IBookingRepository.Load(int bookingId)
        {
            var model = _db.BookingEntities.SingleOrDefault(a => a.Id == bookingId);
            if (model == null) throw new Exception("Bookingen findes ikke i databasen");
            return model;
        }

        BookingResultDto IBookingRepository.Get(int bookingId)
        {
            var dbEntity = _db.BookingEntities.AsNoTracking().Include(a => a.Medarbejder).FirstOrDefault(a => a.Id == bookingId);
            if (dbEntity == null) throw new Exception("Booking findes ikke i databasen");

            return new BookingResultDto
            {
                MedarbejderNavn = dbEntity.Medarbejder.Navn,
                Id = dbEntity.Id,
                MedarbejderId = dbEntity.MedarbejderId,
                OpgaveId = dbEntity.OpgaveId,
                SlutDato = dbEntity.SlutDato,
                StartDato = dbEntity.StartDato
            };
        }

        IEnumerable<BookingGetAllResulstDto> IBookingRepository.GetAll()
        {
            foreach (var entity in _db.BookingEntities.Include(a => a.Medarbejder))
            {
                yield return new BookingGetAllResulstDto
                {
                    Id = entity.Id,
                    MedarbejderNavn = entity.Medarbejder.Navn,
                    MedarbejderTitel = entity.Medarbejder.Titel,
                    StartDato = entity.StartDato,
                    SlutDato = entity.SlutDato,
                };

            }

        }

        IEnumerable<FindMedarbejderDto> IBookingRepository.FindMedarbejder(string type)
        {

            foreach (var entity in _db.KompetenceEntities.Where(a => a.Navn == type).Include(a => a.MedarbejderListe)
                .SelectMany(a => a.MedarbejderListe).Include(a => a.BookingListe)
                .SelectMany(a => a.BookingListe).OrderBy(a => a.SlutDato).ToList())
                     
            yield return new FindMedarbejderDto
            {
                MedarbejderId = entity.MedarbejderId,
                startDato = entity.StartDato,
                SlutDato = entity.SlutDato
            };


        }
    }
}